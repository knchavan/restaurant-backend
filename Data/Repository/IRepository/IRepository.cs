using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace restaurant_backend.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Remove(T entity);
    }
}