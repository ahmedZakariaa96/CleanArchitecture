namespace Infrastructure.Persistence.Repositories.Base.RepositoryBase
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionAsTracking(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(string id);

        void Create(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        IDbContextTransaction BeginTransaction();
        public void Commit();
        public void RollBack();
    }
}