﻿using Domain.Interfaces.Base;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Domain
{
    public class User : IBaseEntity
    {

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public Int16 TypeId { get; set; }
        public string TC { get; set; }
        [Required(ErrorMessage = "Adı Alanını Boş Geçmeyiniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Alanını Boş Geçmeyiniz")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Email Alanını Boş Geçmeyiniz")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Geçerli Bir Email Adresi Giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon Alanını Boş Geçmeyiniz")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Cinsiyet Alanını Boş Geçmeyiniz")]
        public string Gender { get; set; }
        //[Required(ErrorMessage = "Şifre Alanını Boş Geçmeyiniz")]
        [JsonIgnore]
        public string Password { get; set; }
        public string PhotoUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Doğum Tarihi Alanını Boş Geçmeyiniz")]
        [Range(typeof(DateTime), "1/1/1800","1/1/2999",  ErrorMessage = "Doğum Tarihinizi Giriniz!")]
        public DateTime Birthdate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Int16 RoleGroupId { get; set; }
        public int UserDetailId { get; set; }
        public int DoctorDetailId { get; set; }
        public decimal AccountBalance { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime? RefreshTokenEndTime { get; set; }
        [JsonIgnore]
        public string RefreshTokenMobile { get; set; }
        [JsonIgnore]
        public DateTime? RefreshTokenEndTimeMobile { get; set; }

        public UserDetail UserDetail { get; set; }

        public DoctorDetail DoctorDetail { get; set; }

        public UserType UserType { get; set; }
        [JsonIgnore]
        public RoleGroup RoleGroup { get; set; }
        public ICollection<RelUserDepartment> RelUserDepartments { get; set; }
        public ICollection<Address> Address { get; set; }
        [JsonIgnore]
        public ICollection<Appointment> Appointment { get; set; }
        [JsonIgnore]
        public ICollection<DailyCheck> DailyCheck { get; set; }
        [JsonIgnore]
        public ICollection<DailyCheck> NurseDailyCheck { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<AppointmentProcess> AppointmentProcess { get; set; }
        [NotMapped]
        [JsonIgnore]
        public ICollection<NotifyWarning> NotifyWarnings { get; set; }
        public virtual ICollection<UsedCampaign> UsedCampaigns { get; set; }
        public string FullName()
        {
            return this.Name + " " + this.SurName;
        }
    }
}
