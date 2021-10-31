using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class NotifyWarning
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public short Status { get; set; }

        public short RequestType { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
    }
}
