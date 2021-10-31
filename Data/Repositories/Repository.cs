using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Data.Interfaces;
using Domain.Interfaces.Base;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext context;

        protected DbSet<T> dbset => context.Set<T>();

        public Repository(DataContext context)
        {
            this.context = context;
        }
        public virtual T Find(object id, string includes = "")
        {
            if (id == null)
                return null;
            if (!string.IsNullOrEmpty(includes))
            {
                var query = Includes(includes);
                var item = dbset.Find(id);
                return query.FirstOrDefault(p => p == item);
            }
            else
                return dbset.Find(id);
        }
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter == null)
                return null;
            return dbset.Where(Filter).AsQueryable();
        }
        public virtual IQueryable<T> Include(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter == null)
                return null;
            return dbset.Include(Filter);
        }
        public virtual bool RemoveById(object id)
        {
            try
            {
                T entity = dbset.Find(id);
                dbset.Attach(entity);
                dbset.Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception exx)
            {
                return false;
            }
        }
        public virtual bool Remove(T entity)
        {
            try
            {
                dbset.Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual int Remove(Expression<Func<T, bool>> Filter = null)
        {
            try
            {
                T entity = dbset.FirstOrDefault(Filter);
                dbset.Attach(entity);
                dbset.Remove(entity);
                return context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public virtual int RemoveRange(Expression<Func<T, bool>> Filter = null)
        {
            try
            {
                if (Filter == null)
                    return 0;
                dbset.RemoveRange(dbset.Where(Filter));
                return context.SaveChanges(); ;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public virtual T RemoveByIdandGet(object id)
        {
            try
            {
                T entity = dbset.Find(id);
                dbset.Attach(entity);
                dbset.Remove(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual bool Update(T entity)
        {
            try
            {
                dbset.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual bool Add(T entity, Expression<Func<T, bool>> InsertControl = null)
        {
            try
            {
                if (InsertControl != null)
                    if (dbset.FirstOrDefault(InsertControl) != null)
                        return false;
                dbset.Add(entity);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual List<T> ToList()
        {
            return dbset.ToList();
        }
        public virtual int CountByWhere(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter == null)
                return 0;
            return dbset.Count(Filter);
        }
        public virtual T FirstOrDefault(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter == null)
                return dbset.FirstOrDefault();
            return dbset.FirstOrDefault(Filter);
        }
        public virtual IQueryable<T> Includes(string Includes)
        {
            var query = dbset.AsQueryable();
            var incExpression = Includes.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string include in incExpression)
                query = query.Include(include);
            return query;
        }
    }
}
