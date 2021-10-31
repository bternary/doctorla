using Data.Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UserUpdateReqModel
    {
        public User User { get; set; }
        public FileReqModel UserImage { get; set; }
    }
}
