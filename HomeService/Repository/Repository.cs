using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly DAL.HSEntities context;

        public Repository()
        {
            this.context = new DAL.HSEntities();
        }

        #region Delete

        public int Delete(TEntity obj)
        {
            if (obj != null)
            {
                try
                {
                    if (context.Entry<TEntity>(obj).State == EntityState.Detached) context.Set<TEntity>().Attach(obj);
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

        public int Delete(IEnumerable<TEntity> objects)
        {
            if (objects != null)
            {
                try
                {
                    foreach (var item in objects)
                    {
                        if (context.Entry<TEntity>(item).State == EntityState.Detached) context.Set<TEntity>().Attach(item);
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
                foreach (TEntity item in context.Set<TEntity>())
                {
                    if (context.Entry<TEntity>(item).State == EntityState.Detached) context.Set<TEntity>().Attach(item);
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
                foreach (TEntity item in context.Set<TEntity>())
                {
                    if (context.Entry<TEntity>(item).State == EntityState.Detached) context.Set<TEntity>().Attach(item);
                    context.Entry(item).State = EntityState.Deleted;
                }
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> DeleteAsync(TEntity obj)
        {
            if (obj != null)
            {
                try
                {
                    if (context.Entry<TEntity>(obj).State == EntityState.Detached) context.Set<TEntity>().Attach(obj);
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

        public async Task<int> DeleteAsync(IEnumerable<TEntity> objects)
        {
            if (objects != null)
            {
                try
                {
                    foreach (var item in objects)
                    {
                        if (context.Entry<TEntity>(item).State == EntityState.Detached) context.Set<TEntity>().Attach(item);
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

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().SingleOrDefault(predicate) != null;
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(predicate) != null;
        }

        public TEntity GetById(int primaryKey)
        {
            return context.Set<TEntity>().Find(primaryKey);
        }

        public async Task<TEntity> GetByIdAsync(int primaryKey)
        {
            return await context.Set<TEntity>().FindAsync(primaryKey);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        #region Insert, Update

        public int Insert(TEntity obj)
        {
            if (obj != null)
            {
                context.Set<TEntity>().Add(obj);
                return context.SaveChanges();
            }
            return 0;
        }

        public int Insert(IEnumerable<TEntity> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                context.Set<TEntity>().AddRange(objects);
                return context.SaveChanges();
            }
            return 0;
        }

        public async Task<int> InsertAsync(TEntity obj)
        {
            if (obj != null)
            {
                context.Set<TEntity>().Add(obj);
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> InsertAsync(IEnumerable<TEntity> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                context.Set<TEntity>().AddRange(objects);
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public int InsertOrUpdate(TEntity obj)
        {
            if (obj != null)
            {
                if (context.Entry(obj).State == EntityState.Detached)
                {
                    context.Set<TEntity>().Attach(obj);
                }

                context.Entry<TEntity>(obj).State = EntityState.Modified;
                //context.Entry(obj).CurrentValues.SetValues(obj);

                return context.SaveChanges();
            }
            return 0;
        }

        public int InsertOrUpdate(IEnumerable<TEntity> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                try
                {
                    foreach (TEntity item in objects)
                    {
                        if (context.Entry<TEntity>(item).State == EntityState.Detached) context.Set<TEntity>().Attach(item);
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

        public async Task<int> InsertOrUpdateAsync(TEntity obj)
        {
            if (obj != null)
            {
                if (context.Entry(obj).State == EntityState.Detached)
                {
                    context.Set<TEntity>().Attach(obj);
                }

                context.Entry(obj).State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> InsertOrUpdateAsync(IEnumerable<TEntity> objects)
        {
            if (objects != null && objects.Count() > 0)
            {
                try
                {
                    foreach (TEntity item in objects)
                    {
                        if (context.Entry<TEntity>(item).State == EntityState.Detached) context.Set<TEntity>().Attach(item);
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

        public List<TEntity> Select()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<List<TEntity>> SelectAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> Set()
        {
            return context.Set<TEntity>();
        }
       
    }
}
