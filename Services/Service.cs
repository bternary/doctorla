using Data.Interfaces;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Extensions;
using System.Linq;
using Domain.Models;

namespace Services
{
    public class Service<T> : IService<T> where T : class
    {
        internal IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.ToList();
        }

        public virtual T GetItem(int Id, string includes = "")
        {
            return _repository.Find(Id, includes);
        }



        public virtual bool Remove(T Item)
        {
            return _repository.Remove(Item);
        }

        public virtual bool RemoveById(int id)
        {
            return _repository.RemoveById(id);
        }
        public virtual GenericServiceListModel<T> GetItems(SortingPagingInfo sorting, string Includes = "", Expression<Func<T, bool>> Filter = null)
        {
            var result = new GenericServiceListModel<T>();
            var query = _repository.Includes(Includes);
            if (Filter != null)
                query = query.Where(Filter);
            query = query.OrderBy(!string.IsNullOrEmpty(sorting.SortField) ? sorting.SortField : "Id", sorting.SortDirection);
            result.TotalCount = query.Count();
            result.CurrentPage = sorting.PageIndex;
            if (sorting.PageIndex == 0)
            {
                result.PageSize = result.TotalCount;
                result.Items = query.ToList();
            }
            else
            {
                result.PageSize = sorting.PageSize;
                result.Items = query.Skip(sorting.PageSize * (sorting.PageIndex - 1))
              .Take(sorting.PageSize);
            }
            return result;
        }
        public virtual bool Add(T Item)
        {
            return _repository.Add(Item);
        }
    }
}
