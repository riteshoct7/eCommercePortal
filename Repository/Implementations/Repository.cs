using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {

        #region Fields

        private readonly AppDbContext db;
        internal DbSet<T> dbSet;

        #endregion

        #region Constructors

        public Repository(AppDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        #endregion

        #region Methods

        #region Sync Methods

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Add(T obj)
        {
            db.Add(obj);
        }

        public void Update(T obj)
        {
            db.Update(obj);
        }

        public void Remove(T obj)
        {
            db.Remove(obj);
        }

        public void Remove(object id)
        {
            var obj = dbSet.Find(id);
            if (obj != null)
            {
                Remove(obj);
            }
        } 

        #endregion

        #region Async Methods

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<int> SaveAsync(T obj)
        {
            db.Add(obj);
            var insertResult = await db.SaveChangesAsync();
            return insertResult;
        }

        public async Task<int> UpdateAsync(T obj)
        {
            db.Update(obj);
            var updateResult = await db.SaveChangesAsync();
            return updateResult;
        }

        public async Task<int> RemoveAsync(T obj)
        {
            db.Remove(obj);
            var removeResult = await db.SaveChangesAsync();
            return removeResult;
        }

        public async Task<int> RemoveAsync(object id)
        {
            var findResult = await dbSet.FindAsync(id);
            if (findResult != null)
            {
                var removeResult = await RemoveAsync(findResult);
                return removeResult;
            }
            return 0;
        }

        #endregion

        #endregion

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return db.Set<TEntity>().ToList();
        //}

        //public TEntity GetById(object id)
        //{
        //    return db.Set<TEntity>().Find(id);
        //}

        //public void Add(TEntity entity)
        //{
        //    db.Set<TEntity>().Add(entity);
        //}

        //public void Update(TEntity entity)
        //{
        //    db.Set<TEntity>().Update(entity);
        //}
        //public void Remove(TEntity entity)
        //{
        //    db.Set<TEntity>().Remove(entity);
        //}
        //public void Delete(object id)
        //{
        //    TEntity entity = db.Set<TEntity>().Find(id);
        //    if (entity != null)
        //    {
        //        db.Set<TEntity>().Remove(entity);
        //    }
        //}
        //public int SaveChanges()
        //{
        //    return db.SaveChanges();
        //}

    }
}
