﻿using Microsoft.EntityFrameworkCore;
using MyEats.Database;
using MyEats.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyEats.RepositoryLibrary.Contracts
{
    public class RepositoryBase<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly DataContext context;

        public RepositoryBase(DataContext context)
        {
            this.context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<IEnumerable<T>>().AddAsync(entities);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
