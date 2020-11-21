using System.Collections.Generic;
using System.Threading.Tasks;
using WillEnergy.Application.Samples.Infrastructure.Repositories;
using WillEnergy.Domain.Entities;
using WillEnergy.Infrastructure.Persistence.Repositories.Base;

namespace WillEnergy.Infrastructure.Persistence.Repositories.Write
{
    public class StreetsWriteRepository : BaseWriteRepository, IStreetsWriteRepository
    {
        public StreetsWriteRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task SaveStreets(IList<Street> streets)
        {
            await Context.Streets.AddRangeAsync(streets);
            await Context.SaveChangesAsync();
        }
    }
}
