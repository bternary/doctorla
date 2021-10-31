using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class AppointmentProcess
    {
        public int Id { get; set; }
        public DateTime IDate { get; set; }
        public int AppointmentId { get; set; }
        public bool IsDoctor { get; set; }
        public string ProcessMessage { get; set; }
        public int ProcessTypes { get; set; }
        public virtual User User { get; set; }
        [JsonIgnore]
        public Appointment Appointment { get; set; }
    }
}
