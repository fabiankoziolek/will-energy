using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WillEnergy.Application.Samples.Infrastructure.Repositories;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.ValueObjects.Identifiers;
using WillEnergy.Infrastructure.Persistence.Repositories.Base;

namespace WillEnergy.Infrastructure.Persistence.Repositories.Write
{
    public class SamplesWriteRepository : BaseWriteRepository, ISamplesWriteRepository
    {
        public SamplesWriteRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Sample> Find(SampleId id)
        {
            return await Context.Samples.FirstOrDefaultAsync(x => x.DatabaseId == id.Value);
        }
    }
}
