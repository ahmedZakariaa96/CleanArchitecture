namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
    
         

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder.Entity<VwTraineeInfo>().ToView(nameof(VwTraineeInfo));
        }
    }

    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        optionsBuilder.UseSqlServer("Server=.;Database=MOTADB;Trusted_Connection=True;MultipleActiveResultSets=True;trustservercertificate=True;");

    //        return new ApplicationDbContext(optionsBuilder.Options);
    //    }
    //}
}