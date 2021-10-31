using Data.Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class AppointmentBuyResult : BuyResult
    {
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Appointment Appointment { get; set; }
        [JsonIgnore]
        public double DiscountAmount { get; set; }
    }
}
