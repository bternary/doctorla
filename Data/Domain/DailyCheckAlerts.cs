using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class DailyCheckAlerts
    {
        public int Id { get; set; }
        public int DailyCheckId { get; set; }
        public DateTime AlertDay { get; set; }
        public int DayCounter { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public DailyCheck DailyCheck { get; set; }
    }
}
