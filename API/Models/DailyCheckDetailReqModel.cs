using Domain.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class DailyCheckDetailReqModel
    {
        public int DailyCheckId { get; set; }
        public List<DailyCheckValues> Values { get; set; }
        public List<FileReqModel> Files { get; set; }
    }
}
