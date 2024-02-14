namespace Utilities.Repositories
{
    public interface IRepository<T> where T : class
    {
        #region Transaction Operations

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region CRUD Operations

        Task<Guid> Add(T entity);
        Task<bool> Update(T entity);
        Task<T> GetByID(Guid ID);
        Task<IEnumerable<T>> GetAll();
        Task<int> Count();
        Task<bool> Delete(Guid ID);
        Task<bool> Any();
        Task<bool> SetPassive(Guid ID);

        #endregion
    }
}