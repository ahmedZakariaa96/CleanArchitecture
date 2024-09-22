namespace Infrastructure.Persistence.Repositories.Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public IRepositoryBase<T> Repository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbContext);
            return repo;
        }
    }
}