using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeamTools.Data.Contracts
{
    public interface IRepository<T>
    {
        void Add(T entity);

        IEnumerable<T> All();

        IEnumerable<T> All(Expression<Func<T, bool>> filter);

        void Delete(T entity);
    }
}
