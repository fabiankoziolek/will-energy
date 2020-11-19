using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Application.Samples.Infrastructure.Repositories
{
    public interface ISamplesReadRepository
    {
        Task<IList<Sample>> FindSortedActiveWithOfficePeriod(DateTimeOffset from, UserId userId);
    }
}
