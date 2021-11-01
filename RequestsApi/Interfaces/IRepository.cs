using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Get
        TEntity Get(int id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        bool Any(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        #endregion

        #region Update
        void Update(TEntity entity);
        #endregion

        #region Remove
        void Remove(TEntity entity);
        void RemoveRange(IQueryable<TEntity> entities);
        #endregion

        #region  GetAsync
        Task<TEntity> GetAsync(int id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region GetWithInclude
        TEntity FirstOrDefaultInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> FindInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includes);
        #endregion

        #region GetWithIncludeAsync
        Task<TEntity> FirstOrDefaultIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> FindIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> GetAllIncludeAsync(params Expression<Func<TEntity, object>>[] includes);
        #endregion
    }
}