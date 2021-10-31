using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PackageDetailModel
    {
        public Package Package { get; set; }
        public User Doctor { get; set; }
    }
}
