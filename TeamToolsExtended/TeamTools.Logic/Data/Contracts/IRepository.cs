using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeamTools.Logic.Data.Contracts
{
    public interface IRepository<T>
    {
        void Add(T entity);

        T GetById(int id);

        T GetById(string id);

        IEnumerable<T> All();

        IEnumerable<T> All(Expression<Func<T, bool>> filter);

        void Delete(T entity);
    }
}
