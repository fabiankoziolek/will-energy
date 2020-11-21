using System.Collections.Generic;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Domain.Core.Measurements;

namespace WillEnergy.Application.Measurements.Queries
{
    public class GetHistoricalAirMeasurementsForStation : IQuery<IList<Measurement>>
    {
        public GetHistoricalAirMeasurementsForStation(in int sensorId)
        {
            SensorId = sensorId;
        }

        public int SensorId { get; set; }
    }
}
