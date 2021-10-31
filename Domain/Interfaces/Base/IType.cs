using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Base
{
    public interface IType
    {
        public string Name { get; set; }
        public string DefaultName { get; set; }
    }
}
