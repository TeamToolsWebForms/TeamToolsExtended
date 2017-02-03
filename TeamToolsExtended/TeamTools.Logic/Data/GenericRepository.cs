﻿using System;
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
            this.dbContext = dbContext;
            this.set = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Added;
        }

        public T GetById(int id)
        {
            var record = this.set.Find(id);
            return record;
        }

        public T GetById(string id)
        {
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

        public void Delete(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}