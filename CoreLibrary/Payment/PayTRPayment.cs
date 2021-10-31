using Data.Domain;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using CoreLibrary.MethodExtensions;

namespace CoreLibrary.Payment
{
    public class PayTRPayment
    {
        private static string merchant_id; //= "171781";
        private static string merchant_key;// = "XKtcBZXaF5YjuPKP";
        private static string merchant_salt;// = "SrPzE6zLeB31HPfk";
        private static string baseUrl;
        static PayTRPayment()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                IConfiguration config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                merchant_id = config["Payment:merchant_id"];
                merchant_key = config["Payment:merchant_key"];
                merchant_salt = config["Payment:merchant_salt"];
                baseUrl = config["Payment:baseUrl"];
            }
        }

        public static OperationResultModel ValidateStartAppointmentPayment(User user)
        {
            var result = new OperationResultModel { IsSuccess = true };

            if (!ValidatorExtensions.IsValidCitizenshipNumber(user.TC))
            {
                result.IsSuccess = false;
                result.Message = "TC kimlik numaranız tanımlı olmadığından dolayı, işleme devam edilememektedir. Lütfen TC kimlik numaranızı tanımlayınız.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(user?.Address?.FirstOrDefault().AddressDetail))
            {
                result.IsSuccess = false;
                result.Message = "Fatura adresiniz tanımlı olmadığından dolayı, işleme devam edilememektedir. Lütfen fatura adresinizi tanımlayınız.";
                return result;
            }            

            return result;
        }

        public static object StartAppointmentPayment(User user, Appointment appointment, double usediscount, string ip)
        {
            // ####################### DÜZENLEMESİ ZORUNLU ALANLAR #######################
            //
            // API Entegrasyon Bilgileri - Mağaza paneline giriş yaparak BİLGİ sayfasından alabilirsiniz.

            //
            // Müşterinizin sitenizde kayıtlı veya form vasıtasıyla aldığınız eposta adresi
            string emailstr = user.Email;
            //
            // Tahsil edilecek tutar. 9.99 için 9.99 * 100 = 999 gönderilmelidir.

            int payment_amountstr = Convert.ToInt32((appointment.SessionPrice - (decimal)usediscount) * 100);
            //
            // Sipariş numarası: Her işlemde benzersiz olmalıdır!! Bu bilgi bildirim sayfanıza yapılacak bildirimde geri gönderilir.

            Random rnd = new Random();
            string unique = rnd.Next(100000, 999999).ToString();

            string merchant_oid = "0p" + appointment.SessionCode + "p" + user.Id + "p" + Convert.ToInt32(usediscount * 100) + "p" + unique;
            //
            // Müşterinizin sitenizde kayıtlı veya form aracılığıyla aldığınız ad ve soyad bilgisi
            string user_namestr = user.Name + " " + user.SurName;
            //
            // Müşterinizin sitenizde kayıtlı veya form aracılığıyla aldığınız adres bilgisi
            string user_addressstr = user.Address.FirstOrDefault().AddressDetail;

            user_addressstr = user_addressstr == null ? "Test" : user_addressstr; // TODO : Kulalnıcı adresi öncesinde valide edilip doğru kaydedilmeli


            //
            // Müşterinizin sitenizde kayıtlı veya form aracılığıyla aldığınız telefon bilgisi
            string user_phonestr = user.Phone;
            //
            // Başarılı ödeme sonrası müşterinizin yönlendirileceği sayfa
            // !!! Bu sayfa siparişi onaylayacağınız sayfa değildir! Yalnızca müşterinizi bilgilendireceğiniz sayfadır!
            // !!! Siparişi onaylayacağız sayfa "Bildirim URL" sayfasıdır (Bakınız: 2.ADIM Klasörü).
            string merchant_ok_url = $"{baseUrl}/Doctorla/Profilim";
            //
            // Ödeme sürecinde beklenmedik bir hata oluşması durumunda müşterinizin yönlendirileceği sayfa
            // !!! Bu sayfa siparişi iptal edeceğiniz sayfa değildir! Yalnızca müşterinizi bilgilendireceğiniz sayfadır!
            // !!! Siparişi iptal edeceğiniz sayfa "Bildirim URL" sayfasıdır (Bakınız: 2.ADIM Klasörü).
            string merchant_fail_url = $"{baseUrl}/Doctorla/PaymentFailed";
            //        
            // !!! Eğer bu örnek kodu sunucuda değil local makinanızda çalıştırıyorsanız
            // buraya dış ip adresinizi (https://www.whatismyip.com/) yazmalısınız. Aksi halde geçersiz paytr_token hatası alırsınız.

            string user_ip = ip;


            //
            // ÖRNEK $user_basket oluşturma - Ürün adedine göre object'leri çoğaltabilirsiniz
            //object[][] user_basket = {
            //new object[] {"Randevu Detayı || Bölüm Adı:"+ appointment.Department.Name + " Doktor Adı:"+ appointment.DoctorName+ "  Randevu Süresi:" +appointment.AppointmentDate.ToShortDateString() + " " + appointment.AppointmentDate.ToString("HH:mm") + "-" + appointment.AppointmentFinishDate.ToString("HH:mm") +"   Kullanılan Kredi Tutarı:"+ usediscount, appointment.SessionPrice - usediscount, 1 } // 1. ürün (Ürün Ad - Birim Fiyat - Adet)
            //};
            object[][] user_basket = {
            new object[] {"Danışmanlık Hizmeti" ,(double) appointment.SessionPrice - usediscount, 1 } // 1. ürün (Ürün Ad - Birim Fiyat - Adet)
            };



            /* ############################################################################################ */


            // İşlem zaman aşımı süresi - dakika cinsinden
            string timeout_limit = "2";
            //
            // Hata mesajlarının ekrana basılması için entegrasyon ve test sürecinde 1 olarak bırakın. Daha sonra 0 yapabilirsiniz.
            string debug_on = "1";
            //
            // Mağaza canlı modda iken test işlem yapmak için 1 olarak gönderilebilir.
            string test_mode = "0";
            //
            // Taksit yapılmasını istemiyorsanız, sadece tek çekim sunacaksanız 1 yapın
            string no_installment = "0";
            //
            // Sayfada görüntülenecek taksit adedini sınırlamak istiyorsanız uygun şekilde değiştirin.
            // Sıfır (0) gönderilmesi durumunda yürürlükteki en fazla izin verilen taksit geçerli olur.
            string max_installment = "3";
            //
            // Para birimi olarak TL, EUR, USD gönderilebilir. USD ve EUR kullanmak için kurumsal@paytr.com 
            // üzerinden bilgi almanız gerekmektedir. Boş gönderilirse TL geçerli olur.
            string currency = "TL";
            //
            // Türkçe için tr veya İngilizce için en gönderilebilir. Boş gönderilirse tr geçerli olur.
            string lang = "";


            // Gönderilecek veriler oluşturuluyor
            NameValueCollection data = new NameValueCollection();
            data["merchant_id"] = merchant_id;
            data["user_ip"] = user_ip;
            data["merchant_oid"] = merchant_oid;
            data["email"] = emailstr;
            data["payment_amount"] = payment_amountstr.ToString();
            //
            // Sepet içerği oluşturma fonksiyonu, değiştirilmeden kullanılabilir.

            string user_basket_json = JsonSerializer.Serialize(user_basket);
            string user_basketstr = Convert.ToBase64String(Encoding.UTF8.GetBytes(user_basket_json));
            data["user_basket"] = user_basketstr;
            //
            // Token oluşturma fonksiyonu, değiştirilmeden kullanılmalıdır.
            string Birlestir = string.Concat(merchant_id, user_ip, merchant_oid, emailstr, payment_amountstr.ToString(), user_basketstr, no_installment, max_installment, currency, test_mode, merchant_salt);
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchant_key));
            byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(Birlestir));
            data["paytr_token"] = Convert.ToBase64String(b);
            //
            data["debug_on"] = debug_on;
            data["test_mode"] = test_mode;
            data["no_installment"] = no_installment;
            data["max_installment"] = max_installment;
            data["user_name"] = user_namestr;
            data["user_address"] = user_addressstr;
            data["user_phone"] = user_phonestr;
            data["merchant_ok_url"] = merchant_ok_url;
            data["merchant_fail_url"] = merchant_fail_url;
            data["timeout_limit"] = timeout_limit;
            data["currency"] = currency;
            data["lang"] = lang;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] result = client.UploadValues("https://www.paytr.com/odeme/api/get-token", "POST", data);
                string ResultAuthTicket = Encoding.UTF8.GetString(result);
                dynamic json = JValue.Parse(ResultAuthTicket);
                json.token = "https://www.paytr.com/odeme/guvenli/" + json.token;
                if (json.status == "success")
                {
                    return json;
                }
                else
                {
                    return json;
                }
            }
        }

        public static object StartDailyCheckPayment(User user, Package package, int doktorId, double price, double day, string ip)
        {
            string emailstr = user.Email;

            double payment_amountstr = price * 100;

            Random rnd = new Random();
            string unique = rnd.Next(100000, 999999).ToString();
            string merchant_oid = "";
            if (doktorId == 0)
                merchant_oid = "2p" + package.Id + "p" + user.Id + "p" + Convert.ToInt16(payment_amountstr) + "p" + day + "p" + unique;
            else
                merchant_oid = "3p" + package.Id + "p" + user.Id + "p" + Convert.ToInt16(payment_amountstr) + "p" + day + "p" + doktorId + "p" + unique;
            string user_namestr = user.Name + " " + user.SurName;
            string user_addressstr = user.Address.FirstOrDefault().AddressDetail;
            string user_phonestr = user.Phone;
            string merchant_ok_url = $"{baseUrl}/Doctorla/Profilim";
            string merchant_fail_url = $"{baseUrl}/Doctorla/PaymentFailed";

            string user_ip = ip;


            object[][] user_basket = {
            new object[] {"Danışmanlık Hizmeti" ,price , 1 } // 1. ürün (Ürün Ad - Birim Fiyat - Adet)
            };


            string timeout_limit = "2";
            string debug_on = "1";
            string test_mode = "0";
            string no_installment = "0";
            string max_installment = "3";
            string currency = "TL";
            string lang = "";


            // Gönderilecek veriler oluşturuluyor
            NameValueCollection data = new NameValueCollection();
            data["merchant_id"] = merchant_id;
            data["user_ip"] = user_ip;
            data["merchant_oid"] = merchant_oid;
            data["email"] = emailstr;
            data["payment_amount"] = payment_amountstr.ToString();
            //
            // Sepet içerği oluşturma fonksiyonu, değiştirilmeden kullanılabilir.

            string user_basket_json = JsonSerializer.Serialize(user_basket);
            string user_basketstr = Convert.ToBase64String(Encoding.UTF8.GetBytes(user_basket_json));
            data["user_basket"] = user_basketstr;
            //
            // Token oluşturma fonksiyonu, değiştirilmeden kullanılmalıdır.
            string Birlestir = string.Concat(merchant_id, user_ip, merchant_oid, emailstr, payment_amountstr.ToString(), user_basketstr, no_installment, max_installment, currency, test_mode, merchant_salt);
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchant_key));
            byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(Birlestir));
            data["paytr_token"] = Convert.ToBase64String(b);
            //
            data["debug_on"] = debug_on;
            data["test_mode"] = test_mode;
            data["no_installment"] = no_installment;
            data["max_installment"] = max_installment;
            data["user_name"] = user_namestr;
            data["user_address"] = user_addressstr;
            data["user_phone"] = user_phonestr;
            data["merchant_ok_url"] = merchant_ok_url;
            data["merchant_fail_url"] = merchant_fail_url;
            data["timeout_limit"] = timeout_limit;
            data["currency"] = currency;
            data["lang"] = lang;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] result = client.UploadValues("https://www.paytr.com/odeme/api/get-token", "POST", data);
                string ResultAuthTicket = Encoding.UTF8.GetString(result);
                dynamic json = JValue.Parse(ResultAuthTicket);
                json.token = "https://www.paytr.com/odeme/guvenli/" + json.token;
                if (json.status == "success")
                {
                    return json;
                }
                else
                {
                    return json;
                }
            }
        }

        public static object StartSupportPayment(Donations donation, string ip)
        {

            string emailstr = donation.Email;
            int payment_amountstr = Convert.ToInt16(donation.Price) * 100;
            Random rnd = new Random();
            string merchant_oid = "1p" + donation.Id;
            string user_namestr = donation.Name;
            string user_addressstr = "Yok";
            string user_phonestr = donation.Phone;
            string merchant_ok_url = $"{baseUrl}/Doctorla/DestekBasarili?destekno=" + donation.Id;
            string merchant_fail_url = $"{baseUrl}/Doctorla/OdemeHatali";
            string user_ip = ip;


            object[][] user_basket = {
            new object[] {donation.DonationCompany+" Destek Kampanyası", donation.Price, 1 } // 1. ürün (Ürün Ad - Birim Fiyat - Adet)
            };


            string timeout_limit = "2";
            string debug_on = "1";
            string test_mode = "0";
            string no_installment = "0";
            string max_installment = "3";
            string currency = "TL";
            string lang = "";


            NameValueCollection data = new NameValueCollection();
            data["merchant_id"] = merchant_id;
            data["user_ip"] = user_ip;
            data["merchant_oid"] = merchant_oid;
            data["email"] = emailstr;
            data["payment_amount"] = payment_amountstr.ToString();

            string user_basket_json = JsonSerializer.Serialize(user_basket);
            string user_basketstr = Convert.ToBase64String(Encoding.UTF8.GetBytes(user_basket_json));
            data["user_basket"] = user_basketstr;

            string Birlestir = string.Concat(merchant_id, user_ip, merchant_oid, emailstr, payment_amountstr.ToString(), user_basketstr, no_installment, max_installment, currency, test_mode, merchant_salt);
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchant_key));
            byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(Birlestir));
            data["paytr_token"] = Convert.ToBase64String(b);
            //
            data["debug_on"] = debug_on;
            data["test_mode"] = test_mode;
            data["no_installment"] = no_installment;
            data["max_installment"] = max_installment;
            data["user_name"] = user_namestr;
            data["user_address"] = user_addressstr;
            data["user_phone"] = user_phonestr;
            data["merchant_ok_url"] = merchant_ok_url;
            data["merchant_fail_url"] = merchant_fail_url;
            data["timeout_limit"] = timeout_limit;
            data["currency"] = currency;
            data["lang"] = lang;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] result = client.UploadValues("https://www.paytr.com/odeme/api/get-token", "POST", data);
                string ResultAuthTicket = Encoding.UTF8.GetString(result);
                dynamic json = JValue.Parse(ResultAuthTicket);
                json.token = "https://www.paytr.com/odeme/guvenli/" + json.token;
                if (json.status == "success")
                {
                    return json;
                }
                else
                {
                    return json;
                }
            }
        }
        public static PaymentResult ValidatePayment()
        {
            PaymentResult result = new PaymentResult { IsSuccess = true };
            try
            {
                using (var serviceScope = ServiceActivator.GetScope())
                {
                    IHttpContextAccessor httpContextAccessor = serviceScope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
                    var context = httpContextAccessor.HttpContext;
                    var Request = context.Request;
                    result.MerchantOid = Request.Form["merchant_oid"];
                    result.Status = Request.Form["status"];
                    string total_amount = Request.Form["total_amount"];
                    string failed_reason_msg = Request.Form["failed_reason_msg"];
                    string hash = Request.Form["hash"];
                    result.Responses = result.MerchantOid.Split('p');
                    string paymenttype = result.Responses[0]; // 0: Appointment   -  1: Donation   - 2&3 DailyCheck & DoctorDailycheck
                    result.PaymentType = (PaymentType)Convert.ToInt32(paymenttype);
                    string Birlestir = string.Concat(result.MerchantOid, merchant_salt, result.Status, total_amount);
                    HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchant_key));
                    byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(Birlestir));
                    string token = Convert.ToBase64String(b);
                    if (hash.ToString() != token || result.Status == "failed")
                    {
                        result.ErrorMessage = failed_reason_msg;
                        result.IsSuccess = false;
                    }
                }
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
