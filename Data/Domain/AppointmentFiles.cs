using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class AppointmentFiles : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public string FileName { get; set; }
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public bool IsDoctor { get; set; }
        [JsonIgnore]
        public Appointment Appointment { get; set; }
    }
}