using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BuyResult
    {
        public BuyStatus Status { get; set; }
        public string Description { get; set; }
    }
    public enum BuyStatus
    {
        Error=0,
        PaymentRedirect=1,
        Success=2,
        PaymentFailed=3
    }
}
