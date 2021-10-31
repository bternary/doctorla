using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Domain
{
    public class RoleGroup : IType
    {
        public Int16 Id { get; set; }
        public string Name { get; set; }
        public string DefaultName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
