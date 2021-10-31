using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class NotifyTokens
    {
        public int Id { get; set; }
        public DateTime IDate { get; set; }
        public DateTime? LastDate { get; set; }
        public int UserId { get; set; }
        public string  Token { get; set; }
        public int userType { get; set; }  // 0: No User ,  1: User  , 2: Doctor
    }
}
