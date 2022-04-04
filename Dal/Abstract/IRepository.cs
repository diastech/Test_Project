using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetEx(Expression<Func<T, bool>> predicate);
        IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes);
    }
}
