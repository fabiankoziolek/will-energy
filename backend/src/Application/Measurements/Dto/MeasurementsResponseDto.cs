using System.Collections.Generic;
using WillEnergy.Domain.Core.Measurements;

namespace WillEnergy.Application.Measurements.Dto
{
    public class MeasurementsResponseDto
    {
        public IList<Measurement> Measures { get; set; }
    }
}
