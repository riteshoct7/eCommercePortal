namespace Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {

        #region Methods

        #region Sync Methods

        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
        void Remove(object id);

        #endregion

        #region Async Methods

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<int> SaveAsync(T obj);
        Task<int> UpdateAsync(T obj);
        Task<int> RemoveAsync(T obj);
        Task<int> RemoveAsync(object id);
        Task<T> FindAsync(object id); 

        #endregion

        #endregion

    }
}
