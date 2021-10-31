using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreLibrary
{
    public class SmsServices
    {
        public static string apiUserCode { get; set; }
        public static string apiUrl { get; set; }
        public static string apiOriginator { get; set; }
        public static string apiPassword { get; set; }
        static SmsServices()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                IConfiguration config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                apiUserCode = config["Sms:apiUserCode"];
                apiPassword = WebUtility.UrlEncode(config["Sms:apiPassword"]);
                apiUrl = config["Sms:apiUrl"];
                apiOriginator = config["Sms:apiOriginator"];
            }
        }
        public static void SendSms(string phone, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                phone = phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "00").Replace("0090", "0");
                var uri = $"{apiUrl}?usercode={apiUserCode}&password={apiPassword}&gsmno={phone}&message={WebUtility.UrlEncode(message)}&msgheader={apiOriginator}&dil=TR";
                var result = client.GetStringAsync(uri).Result;
            }
            // https://api.netgsm.com.tr/sms/send/get/?usercode=8503059424&password=PP26QX4D&gsmno=5067706978&message=testmesaji&msgheader=8503059424&dil=TR
        }
    }
}
