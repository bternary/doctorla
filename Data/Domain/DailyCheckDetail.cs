using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class DailyCheckDetail
    {
        public int Id { get; set; }
        public int DailyCheckId { get; set; }
        public int ValuesTitleId { get; set; }
        public int TitleOrder { get; set; }
        public bool IsNew { get; set; }
        [JsonIgnore]
        public DailyCheck DailyCheck { get; set; }
        public DailyCheckPackagesValues ValuesTitle { get; set; }
        public ICollection<DailyCheckDetailValues> Values { get; set; }
    }
}
