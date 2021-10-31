﻿using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class PackageDetail : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public int ScreenOrder { get; set; }
        public bool IsPremium { get; set; }
        public bool AddDefaultOfferDays { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public virtual IEnumerable<RelPackageDetail> RelPackageDetail { get; set; }
    }
}
