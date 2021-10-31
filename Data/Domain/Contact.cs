using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public DateTime IDate { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
