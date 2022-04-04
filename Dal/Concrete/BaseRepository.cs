using Dal.Abstract;
using Dal.Extensions;
using Data.Abstract;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DiasContext _diasContext;
        private DbSet<T> _entities;
        public BaseRepository(DiasContext diasContext)
        {
            _diasContext = diasContext;
            _entities = diasContext.Set<T>();
        }

        public void Add(T entity)
        {
            _diasContext.Set<T>().Add(entity);
            _diasContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _diasContext.Set<T>().Remove(entity);
            _diasContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _diasContext.Set<T>().AsNoTracking();//entity framework e izlememesini söylüyodur.
        }

        public T GetById(int Id)
        {
            return _diasContext.Set<T>().Find(Id);
        }

        public IQueryable<T> GetEx(Expression<Func<T, bool>> predicate)
        {
            return _diasContext.Set<T>().Where(predicate).AsNoTracking();
        }

        public IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes)
        {
            return _entities.IncludeMultiple(includes);
        }

        public void Update(T entity)
        {
            //_diasContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_diasContext.Entry<T>(entity).State = EntityState.Modified;
            //_diasContext.Entry(entity).State = EntityState.Modified;
            //_diasContext.Entry<T>(entity).State = EntityState.Added;

            //_diasContext.Entry(entity).State = EntityState.Detached;
            _diasContext.Set<T>().Update(entity);
            
            _diasContext.SaveChanges();
        }
    }
}
