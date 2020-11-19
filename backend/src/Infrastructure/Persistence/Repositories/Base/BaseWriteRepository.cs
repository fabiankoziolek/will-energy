using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using WillEnergy.Application.Common.Interfaces;

namespace WillEnergy.Infrastructure.Persistence.Repositories.Base
{
    public abstract class BaseWriteRepository : IBaseWriteRepository
    {
        protected ApplicationDbContext Context { get; }

        protected BaseWriteRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public Task<IDbContextTransaction> BeginTransaction()
        {
            return Context.Database.BeginTransactionAsync();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
