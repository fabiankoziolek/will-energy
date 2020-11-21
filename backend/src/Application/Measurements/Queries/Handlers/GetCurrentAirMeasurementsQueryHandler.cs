using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Measurements.Dto;

namespace WillEnergy.Application.Measurements.Queries.Handlers
{
    public class GetCurrentAirMeasurementsQueryHandler : QueryHandler<GetCurrentMeasurementsQuery, IList<MeasurementDto>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetCurrentAirMeasurementsQueryHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<IList<MeasurementDto>> Handle(GetCurrentMeasurementsQuery request)
        {
            return _mapper.Map<IList<MeasurementDto>>(await _mediator.Send(new GetCurrentAirMeasurementsFromSourceQuery()));
        }
    }
}
