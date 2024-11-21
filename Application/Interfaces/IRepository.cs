using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EnergySaverAPI.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
