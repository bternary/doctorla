using Data.Domain;
using Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(DataContext context) : base(context)
        {

        }
        public List<Department> Search()
        {
            var result = new List<Department>();
            result = Where(w => w.IsActive && !w.IsDeleted).ToList();
            return result;
        }
    }
}
