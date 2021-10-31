using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Domain
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime IDate { get; set; }
        public string Page { get; set; }
        public string UrlPath { get; set; }
        public string ErrorMessage { get; set; }
        public int LogType { get; set; }

    }
}
