using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Samples.Infrastructure.Repositories;

namespace WillEnergy.Application.Samples.Queries.FindSamples
{
    public class FindSamplesQueryHandler : QueryHandler<FindSamplesQuery, IList<SampleDto>>
    {
        private readonly ISamplesReadRepository _samplesReadRepository;
        private readonly IMapper _mapper;

        public FindSamplesQueryHandler(ISamplesReadRepository samplesReadRepository, IMapper mapper)
        {
            _samplesReadRepository = samplesReadRepository;
            _mapper = mapper;
        }

        public override async Task<IList<SampleDto>> Handle(FindSamplesQuery request)
        {
            var reservations = await _samplesReadRepository.FindSortedActiveWithOfficePeriod(DateTimeOffset.UtcNow, request.UserId);
            return _mapper.Map<IList<SampleDto>>(reservations);
        }
    }
}
