using Data.Domain;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User login(string eposta, string password);
        List<User> Search(int TypeId, int DepartmentId = 0);
        User Get(int UserId);
    }
}
