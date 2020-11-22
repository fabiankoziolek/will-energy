using System;
using System.Threading.Tasks;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Samples.Infrastructure.Repositories;

namespace WillEnergy.Application.Streets.Queries
{
    public class StreetMediaQueryHandler : QueryHandler<StreetMediaQuery, StreetMediaDto>
    {
        private readonly IStreetReadRepository _readRepository;

        public StreetMediaQueryHandler(IStreetReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public override async Task<StreetMediaDto> Handle(StreetMediaQuery query)
        {
            var street = await _readRepository.FindByName(query.StreetName);
            if (street == null)
            {
                return null;
            }

            return new StreetMediaDto
            {
                GasDateConnection = street.GasDateConnection,
                HasGasConnection = street.GasDateConnection.HasValue && street.GasDateConnection.Value <= DateTimeOffset.UtcNow,
                HeatDateConnection = street.HeatDateConnection,
                HasHeatConnection = street.HeatDateConnection.HasValue && street.HeatDateConnection.Value <= DateTimeOffset.UtcNow,
            };
        }
    }
}
