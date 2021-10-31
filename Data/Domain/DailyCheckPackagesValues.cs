using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class DailyCheckPackagesValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsDefault { get; set; }
        public int TitleOrder { get; set; }
        public bool IsDoctor { get; set; }
        public int DoctorId { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public bool IsNew { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<DailyCheckDetail> DailyCheckDetail { get; set; }
        public virtual IEnumerable<RelPackageValues> RelPackageValues { get; set; }
    }
}
