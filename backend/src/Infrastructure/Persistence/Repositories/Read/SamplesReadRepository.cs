using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WillEnergy.Application.Samples.Infrastructure.Repositories;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.ValueObjects.Identifiers;
using WillEnergy.Infrastructure.Persistence.Repositories.Base;

namespace WillEnergy.Infrastructure.Persistence.Repositories.Read
{
    public class SamplesReadRepository : BaseReadRepository, ISamplesReadRepository
    {
        public SamplesReadRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IList<Sample>> FindSortedActiveWithOfficePeriod(DateTimeOffset from, UserId userId)
        {
            return await Context.Samples.AsNoTracking()
                .Where(x => x.Date >= from && !x.IsDeleted && x.UserId == userId)
                .OrderBy(x => x.Date)
                .ToListAsync();
        }
    }
}
