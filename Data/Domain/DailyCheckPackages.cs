﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Domain
{
    public class DailyCheckPackages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PackageValues { get; set; }
        public bool IsPremium { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public List<DailyCheckPackagesValues> DailyCheckPackagesValues { get; set; }
    }
}
