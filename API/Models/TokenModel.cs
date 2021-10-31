using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TokenModel
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public DateTime tokenExpiryTime { get; set; }
        public User profile { get; set; }
    }
}
