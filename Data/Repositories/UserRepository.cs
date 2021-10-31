using Data.Domain;
using Data.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
        public User login(string eposta, string password)
        {
            var data = dbset
                .Include(x => x.UserDetail)
                .Include(x => x.DoctorDetail)
                .Include(x => x.UserType)
                .Where(f => !f.IsDeleted & f.Email == eposta && f.Password == password)
                .FirstOrDefault();
            if (data != null)
                return data;
            return null;
        }

        public List<User> Search(int TypeId, int DepartmentId = 0)
        {
            var result = new List<User>();
            var data = Where(w => w.IsActive && !w.IsDeleted);
            data = data.Where(w => w.TypeId == TypeId);
            data = DepartmentId > 0 ? data.Where(w => w.RelUserDepartments.Any(a => a.DepartmentId == DepartmentId)) : data;
            result = data.ToList();
            return result;
        }
        public User Get(int UserId)
        {
            var result = new User();
            result = FirstOrDefault(w => w.IsActive && !w.IsDeleted && w.Id == UserId);
            return result;
        }
    }
}
