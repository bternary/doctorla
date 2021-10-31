using Data.Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class PackageBuyResult:BuyResult
    {
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Package Package { get; set; }
        [JsonIgnore]
        public int DoctorId { get; set; }
        [JsonIgnore]
        public double Amount { get; set; }
        [JsonIgnore]
        public int ValidityDates { get; set; }
    }
}
