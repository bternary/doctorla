using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class RelUserDepartment : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public int Price { get; set; }
        public int SessionTime { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public Department Department { get; set; }
        [JsonIgnore]
        public User User { get; set;}

    }
}
