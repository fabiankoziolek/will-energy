using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Measurements.Dto;

namespace WillEnergy.Application.Measurements.Queries.Handlers
{
    public class GetWorstSensorMeasurementQueryHandler : QueryHandler<GetWorstSensorMeasurementQuery, MeasurementDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWorstSensorMeasurementQueryHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<MeasurementDto> Handle(GetWorstSensorMeasurementQuery request)
        {
            var measurements = await _mediator.Send(new GetCurrentAirMeasurementsFromSourceQuery());

            return _mapper.Map<MeasurementDto>(measurements.OrderByDescending(m => m.PM10).FirstOrDefault());
        }
    }
}
