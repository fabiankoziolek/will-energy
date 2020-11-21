using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Measurements.Dto;
using WillEnergy.Domain.Core.Measurements;
using WillEnergy.Infrastructure.Client;

namespace WillEnergy.Application.Measurements.Queries.Handlers
{
    public class GetHistoricalAirMeasurementsForStationQueryHandler : QueryHandler<GetHistoricalAirMeasurementsForStation,
        IList<Measurement>>
    {
        private readonly RestClient _client;

        public GetHistoricalAirMeasurementsForStationQueryHandler()
        {
            _client = new RestClient("http://polair.eu");
        }

        public override async Task<IList<Measurement>> Handle(GetHistoricalAirMeasurementsForStation request)
        {
            var httpRequest =
                new NewtonSoftRestRequest($"api/airQLab/last24/Zduńska Wola/{request.SensorId}", Method.GET);
            httpRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await _client.ExecuteAsync<MeasurementsResponseDto>(httpRequest);

            return response.Data?.Measures ?? ArraySegment<Measurement>.Empty;
        }
    }
}
