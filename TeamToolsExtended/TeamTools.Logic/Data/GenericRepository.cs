using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TeamTools.Logic.Data.Contracts;

namespace TeamTools.Logic.Data
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly ITeamToolsDbContext dbContext;
        private readonly IDbSet<T> set;

        public GenericRepository(ITeamToolsDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext").IsNull().Throw();

            this.dbContext = dbContext;
            this.set = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            Guard.WhenArgument(entity, "Entity").IsNull().Throw();

            var entry = this.dbContext.GetState(entity);
            entry.State = EntityState.Added;
        }

        public T GetById(int id)
        {
            Guard.WhenArgument(id, "Id").IsLessThan(0).Throw();

            var record = this.set.Find(id);
            return record;
        }

        public T GetById(string id)
        {
            Guard.WhenArgument(id, "Id").IsNull().Throw();

            var record = this.set.Find(id);
            return record;
        }

        public IEnumerable<T> All()
        {
            return this.set.ToList();
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> filter)
        {
            return this.set.Where(filter).ToList();
        }

        public IEnumerable<T> All<K>(Expression<Func<T, bool>> filter, Expression<Func<T, K>> sort, bool isAscending)
        {
            if (isAscending)
            {
                return this.set.Where(filter).OrderBy(sort).ToList();
            }
            else
            {
                return this.set.Where(filter).OrderByDescending(sort).ToList();
            }
        }

        public void Delete(T entity)
        {
            Guard.WhenArgument(entity, "Entity").IsNull().Throw();

            var entry = this.dbContext.GetState(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            Guard.WhenArgument(entity, "Entity").IsNull().Throw();

            var entry = this.dbContext.GetState(entity);
            entry.State = EntityState.Modified;
        }
    }
}
