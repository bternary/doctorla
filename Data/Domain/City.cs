using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class City : IBaseEntity, IType
    {
        public string Name { get; set; }
        public string DefaultName { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [JsonIgnore]
        public ICollection<County> Counties { get; set; }
    }
}