using System.Collections.Generic;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Measurements.Dto;

namespace WillEnergy.Application.Measurements.Queries
{
    public class GetCurrentMeasurementsQuery : IQuery<IList<MeasurementDto>>
    {
    }
}
