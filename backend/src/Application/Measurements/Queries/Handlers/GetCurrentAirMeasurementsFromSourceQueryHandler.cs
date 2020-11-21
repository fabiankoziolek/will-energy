using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using RestSharp;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Measurements.Dto;
using WillEnergy.Domain.Core.Measurements;
using WillEnergy.Infrastructure.Client;

namespace WillEnergy.Application.Measurements.Queries.Handlers
{
    public class GetCurrentAirMeasurementsFromSourceQueryHandler : QueryHandler<GetCurrentAirMeasurementsFromSourceQuery, IList<Measurement>
    >
    {
        private readonly IMediator _mediator;
        private readonly RestClient _client;

        public GetCurrentAirMeasurementsFromSourceQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
            _client = new RestClient("http://polair.eu/");
        }

        public override async Task<IList<Measurement>> Handle(GetCurrentAirMeasurementsFromSourceQuery request)
        {
            var httpRequest = new NewtonSoftRestRequest($"api/airQLab/latest", Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
            };

            httpRequest.AddQueryParameter("city", "Zduńska Wola");

            var response = await _client.ExecuteAsync<MeasurementsResponseDto>(httpRequest);

            var measurements = response.Data.Measures;

            foreach (var measurement in measurements)
            {
                measurement.Measurements = await _mediator.Send(new GetHistoricalAirMeasurementsForStation(measurement.ID_URZADZENIA));
            }

            return measurements;
        }
    }
}
