using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class PackageChat 
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int DailyCheckId { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsFile { get; set; }

        public DailyCheck DailyCheck { get; set; }
    }
}