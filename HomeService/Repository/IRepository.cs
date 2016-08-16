using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Repository
{
    public interface IRepository<T> where T : class
    {
        #region Delete Methods
        int Delete(IEnumerable<T> objects);
        Task<int> DeleteAsync(IEnumerable<T> objects);
        int Delete(T obj);
        Task<int> DeleteAsync(T obj);
        int DeleteAll();
        Task<int> DeleteAllAsync();
        #endregion

        #region RetieveMethods
        IQueryable<T> Set();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        List<T> Select();
        Task<List<T>> SelectAsync();
        #endregion

        #region SaveMethods
        int Insert(IEnumerable<T> objects);
        Task<int> InsertAsync(IEnumerable<T> objects);
        int Insert(T obj);
        Task<int> InsertAsync(T obj);
        int InsertOrUpdate(IEnumerable<T> objects);
        Task<int> InsertOrUpdateAsync(IEnumerable<T> objects);
        int InsertOrUpdate(T obj);
        Task<int> InsertOrUpdateAsync(T obj);
        #endregion

        bool Exists(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
