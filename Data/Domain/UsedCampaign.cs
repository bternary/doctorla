using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class UsedCampaign : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public int CampaignId { get; set; }
        public int UserId { get; set; }
        public DateTime UsedDate { get; set; }
        [JsonIgnore]
        public virtual Campaign Campaign { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public decimal UsedAmount { get; set; }
    }
}
