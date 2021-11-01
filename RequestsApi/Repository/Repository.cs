using Microsoft.EntityFrameworkCore;
using RequestsApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RequestsApi.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> Entities;

        public Repository(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        #region  Get
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>()
                .Find(id);
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>()
                .FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>()
                .Where(predicate).AsNoTracking();
        }
        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>()
                .Any(predicate);
        }

        #endregion

        #region  Add
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>()
                .Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>()
                .AddRange(entities);
        }
        #endregion

        #region Update
        public void Update(TEntity entity)
        {
            Context.Entry(entity)
                .State = EntityState.Modified;
        }
        #endregion

        #region  Remove
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>()
                .Remove(entity);
        }

        public void RemoveRange(IQueryable<TEntity> entities)
        {
            Context.Set<TEntity>()
                .RemoveRange(entities);
        }
        #endregion

        #region GetWithInclude
        public TEntity FirstOrDefaultInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Include(includes)
                             .FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> FindInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Include(includes)
                .Where(predicate);
        }

        public IQueryable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Include(includes);
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            DbSet<TEntity> dbSet = Context.Set<TEntity>();
            IQueryable<TEntity> query = null;

            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }
        #endregion

        #region  GetAsync
        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region GetWithIncludeAsync
        public Task<TEntity> FirstOrDefaultIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Include(includes)
                             .FirstOrDefaultAsync(predicate);
        }

        public Task<List<TEntity>> FindIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Include(includes)
                .Where(predicate).ToListAsync();
        }

        public Task<List<TEntity>> GetAllIncludeAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Include(includes)
                .ToListAsync();
        }
        #endregion
    }
    }
