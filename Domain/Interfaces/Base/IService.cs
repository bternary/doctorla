using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Base
{
    public interface IService<T> where T : class
    {
        T GetItem(int Id, string includes = "");
        IEnumerable<T> GetAll();
        bool RemoveById(int id);
        bool Remove(T Item);
        GenericServiceListModel<T> GetItems(SortingPagingInfo sorting, string Includes = "", Expression<Func<T, bool>> Filter = null);
        bool Add(T Item);
    }
}
