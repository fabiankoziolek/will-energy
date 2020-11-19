namespace WillEnergy.Infrastructure.Persistence.Repositories.Base
{
    public abstract class BaseReadRepository
    {
        protected ApplicationDbContext Context { get; }

        protected BaseReadRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
