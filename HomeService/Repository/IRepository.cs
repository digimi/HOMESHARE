using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Delete Methods
        int Delete(IEnumerable<TEntity> objects);
        Task<int> DeleteAsync(IEnumerable<TEntity> objects);
        int Delete(TEntity obj);
        Task<int> DeleteAsync(TEntity obj);
        int DeleteAll();
        Task<int> DeleteAllAsync();
        #endregion

        #region RetieveMethods
        IQueryable<TEntity> Set();
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> Select();
        Task<List<TEntity>> SelectAsync();
        #endregion

        #region SaveMethods
        int Insert(IEnumerable<TEntity> objects);
        Task<int> InsertAsync(IEnumerable<TEntity> objects);
        int Insert(TEntity obj);
        Task<int> InsertAsync(TEntity obj);
        int InsertOrUpdate(IEnumerable<TEntity> objects);
        Task<int> InsertOrUpdateAsync(IEnumerable<TEntity> objects);
        int InsertOrUpdate(TEntity obj);
        Task<int> InsertOrUpdateAsync(TEntity obj);
        #endregion

        bool Exists(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
