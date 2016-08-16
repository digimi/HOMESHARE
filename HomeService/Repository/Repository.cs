using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HomeService.Model;

namespace HomeService.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly HSDbmdfEntities context;

        public Repository()
        {
            this.context = new Model.HSDbmdfEntities();
        }

        #region Delete

        public int Delete(T obj)
        {
            if (obj != null)
            {
                try
                {
                    context.Entry(obj).State = EntityState.Deleted;
                    return context.SaveChanges();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return 0;
        }

        public int Delete(IEnumerable<T> objects)
        {
            if (objects != null)
            {
                try
                {
                    foreach (var item in objects)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    return context.SaveChanges();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return 0;
        }

        public int DeleteAll()
        {
            try
            {
                foreach (T item in context.Set<T>())
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                return context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> DeleteAllAsync()
        {
            try
            {
                foreach (T item in context.Set<T>())
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> DeleteAsync(T obj)
        {
            if (obj != null)
            {
                try
                {

                    context.Entry(obj).State = EntityState.Deleted;
                    return await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return 0;
        }

        public async Task<int> DeleteAsync(IEnumerable<T> objects)
        {
            if (objects != null)
            {
                try
                {
                    foreach (var item in objects)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    return await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return 0;
        }

        #endregion

        public void Dispose()
        {
            return;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefault(predicate) != null;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().SingleOrDefaultAsync(predicate) != null;
        }

        public T GetById(int primaryKey)
        {
            return context.Set<T>().Find(primaryKey);
        }

        public async Task<T> GetByIdAsync(int primaryKey)
        {
            return await context.Set<T>().FindAsync(primaryKey);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefault(predicate);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        #region Insert, Update

        public int Insert(T obj)
        {
            if (obj != null)
            {
                context.Set<T>().Add(obj);
                return context.SaveChanges();
            }
            return 0;
        }

        public int Insert(IEnumerable<T> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                context.Set<T>().AddRange(objects);
                return context.SaveChanges();
            }
            return 0;
        }

        public async Task<int> InsertAsync(T obj)
        {
            if (obj != null)
            {
                context.Set<T>().Add(obj);
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> InsertAsync(IEnumerable<T> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                context.Set<T>().AddRange(objects);
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public int InsertOrUpdate(T obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Modified;
                return context.SaveChanges();
            }
            return 0;
        }

        public int InsertOrUpdate(IEnumerable<T> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                try
                {
                    foreach (var item in objects)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    return context.SaveChanges();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return 0;
        }

        public async Task<int> InsertOrUpdateAsync(T obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> InsertOrUpdateAsync(IEnumerable<T> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                try
                {
                    foreach (var item in objects)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    return await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return 0;
        }

        #endregion

        public List<T> Select()
        {
            return context.Set<T>().ToList();
        }

        public async Task<List<T>> SelectAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IQueryable<T> Set()
        {
            return context.Set<T>();
        }
    }
}
