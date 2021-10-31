using Data.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RegisterReqModel
    {
        public User User { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen Ülke Seçiniz!")]
        public int Country { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen Şehir Seçiniz!")]
        public int City { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen İlçe Seçiniz!")]
        public int County { get; set; }
        [Required(ErrorMessage = "Şifre Alanını Boş Geçmeyiniz")]
        public string Password { get; set; }
        public string AddressDetail { get; set; }
        public string DoctorTitle { get; set; }
        public string DoctorUniversity { get; set; }
        public int DoctorDepartment { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsUser { get; set; }
    }
}
