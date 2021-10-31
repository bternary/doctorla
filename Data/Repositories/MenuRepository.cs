using Data.Domain;
using Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(DataContext context) : base(context)
        {

        }
        public List<Menu> Search(int TypeId, int ParentId = 0)
        {
            var result = new List<Menu>();
            var data = Where(w => w.IsActive && !w.IsDeleted);
            data = data.Where(w => w.TypeId == TypeId);
            data = ParentId > 0 ? data.Where(w => w.ParentId == ParentId) : data.Where(w => w.ParentId == 0);
            result = data.ToList();
            return result;
        }
    }
}
