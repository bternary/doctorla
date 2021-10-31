using Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataViews
{
    public class DoctorAppointmentDetail
    {
        public User User { get; set; }
        public Appointment Appointment { get; set; }
        public bool Permission { get; set; }
    }
}
