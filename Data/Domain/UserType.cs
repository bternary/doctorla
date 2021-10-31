using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Domain
{
    public class UserType : IType
    {
        public Int16 Id { get; set; }
        public string Name { get ; set ; }
        public string DefaultName { get ; set ; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
