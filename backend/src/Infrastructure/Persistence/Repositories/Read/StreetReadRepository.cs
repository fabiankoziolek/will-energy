using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WillEnergy.Application.Samples.Infrastructure.Repositories;
using WillEnergy.Domain.Entities;
using WillEnergy.Infrastructure.Persistence.Repositories.Base;

namespace WillEnergy.Infrastructure.Persistence.Repositories.Read
{
    public class StreetReadRepository : BaseReadRepository, IStreetReadRepository
    {
        public StreetReadRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Street> Find(int id)
        {
            return await Context.Streets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Street> FindByName(string name)
        {
            return await Context.Streets
                .FirstOrDefaultAsync(x => x.Name.Contains(name));
        }
    }
}
