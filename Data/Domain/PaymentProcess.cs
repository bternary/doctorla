using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Domain
{
    public class PaymentProcess
    {
        public int Id { get; set; }
        public DateTime IDate { get ; set ; }
        public int userId{ get; set; }
        public int ServiceId{ get; set; }
        public string ProcessMessage { get; set; }
    }
}
