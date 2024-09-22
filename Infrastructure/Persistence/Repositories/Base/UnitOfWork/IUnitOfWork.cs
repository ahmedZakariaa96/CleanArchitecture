namespace Infrastructure.Persistence.Repositories.Base.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> Repository<T>() where T : class;
        Task<int> CompleteAsync(CancellationToken cancellationToken);
        Task<int> CompleteAsync();
    }
}