using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Payment
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public PaymentType PaymentType { get; set; }
        public string MerchantOid { get; set; }
        public string Status { get; set; }
        public string[] Responses{ get; set; }
    }
    public enum PaymentType
    {
        Appointment = 0,
        Support = 1,
        DailyCheck = 2,
        DoctorDailycheck = 3
    }
}
