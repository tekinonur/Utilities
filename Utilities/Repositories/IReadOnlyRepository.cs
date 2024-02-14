namespace Utilities.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        #region Transaction Operations

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region CRUD Operations
        Task<T> GetByID(Guid ID);
        Task<IEnumerable<T>> GetAll();
        Task<int> Count();
        Task<bool> Any();

        #endregion
    }
}
