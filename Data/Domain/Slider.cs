using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class Slider : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IDate { get; set; }
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public int ItemOrder { get; set; }
        public string Action { get; set; }
        public bool IsMobile { get; set; }
        public string Description { get; set; }
    }
}
