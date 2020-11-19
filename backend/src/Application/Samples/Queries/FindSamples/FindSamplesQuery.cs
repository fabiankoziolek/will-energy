using System.Collections.Generic;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Application.Samples.Queries.FindSamples
{
    public class FindSamplesQuery : IQuery<IList<SampleDto>>
    {
        public UserId UserId { get; }

        public FindSamplesQuery(UserId userId)
        {
            UserId = userId;
        }
    }
}
