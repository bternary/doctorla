using Domain.Interfaces.Base;
using System;

namespace Data.Domain
{
    public class Role : IBaseEntity, IType
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime IDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? UUDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? UUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DefaultName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
