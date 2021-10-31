using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
// using Base;
namespace Data.Domain
{
    public class Appointment : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string SessionKey { get; set; }
        public string SessionCode { get; set; }
        public decimal SessionPrice { get; set; }
        public int SessionTime { get; set; }
        public string AppointmentNote { get; set; }
        public string AppointmentDoctorNote { get; set; }
        public int AppointmentRate { get; set; }
        public string AppointmentRateNote { get; set; }
        public string UserCancelReason { get; set; }
        public string DoctorDeleteReason { get; set; }
        public bool InProcess { get; set; }
        public bool IsPreview { get; set; }
        public int InProcessUserId { get; set; }
        public string DonationCompanys { get; set; }
        public DateTime? InProcessDates { get; set; }

        //Appointment Status Types:   0:In Proccess, 1:Success, -1: Cancelled by Doctor, -2: Cancelled by User, -3: DoctorMissingOnSession, -100: Cancelled by Admin
        public int Status { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentFinishDate { get; set; }
        public int DepartmentId { get; set; }
        public int SickId { get; set; }

        public List<AppointmentFiles> AppointmentFiles { get; set; }
        public List<AppointmentProcess> AppointmentProcess { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        // public User Doctor { get; set; }
        public Department Department { get; set; }
        public Sick Sick { get; set; }

    }
}

