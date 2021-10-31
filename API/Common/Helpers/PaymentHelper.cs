using API.Common.Interfaces;
using CoreLibrary.Payment;
using Data.Domain;
using Domain.Interfaces.Base;
using Domain.Models;
using Newtonsoft.Json;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common.Helpers
{
    public class PaymentHelper : IPaymentHelper
    {
        private readonly IService<PaymentProcess> _paymentService;
        public PaymentHelper(IService<PaymentProcess> paymentService)
        {
            _paymentService = paymentService;
        }
        public BuyResult BuyPackage(PackageBuyResult data, string ip)
        {
            dynamic iframelilnk = PayTRPayment.StartDailyCheckPayment(data.User, data.Package, data.DoctorId, data.Amount, data.ValidityDates, ip);
            if (iframelilnk.status.Value == "success")
                data.Description = iframelilnk.token.Value;
            else
            {
                _paymentService.Add(new PaymentProcess()
                {
                    IDate = DateTime.Now,
                    ProcessMessage = JsonConvert.SerializeObject(iframelilnk),
                    ServiceId = 0,
                    userId = 1
                });
                data.Status = BuyStatus.PaymentFailed;
                data.Description = "Ödeme Sırasında Hata Oluştu";
            }
            return data;
        }
        public BuyResult BuyAppointment(AppointmentBuyResult data, string ip)
        {
            dynamic iframelilnk = PayTRPayment.StartAppointmentPayment(data.User, data.Appointment, data.DiscountAmount, ip);
            if (iframelilnk.status.Value == "success")
                data.Description = iframelilnk.token.Value;
            else
            {
                _paymentService.Add(new PaymentProcess()
                {
                    IDate = DateTime.Now,
                    ProcessMessage = JsonConvert.SerializeObject(iframelilnk),
                    ServiceId = 0,
                    userId = 1
                });
                data.Status = BuyStatus.PaymentFailed;
                data.Description = "Ödeme Sırasında Hata Oluştu";
            }
            return data;
        }
    }
}
