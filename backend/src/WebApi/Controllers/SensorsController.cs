using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillEnergy.Application.Measurements.Dto;
using WillEnergy.Application.Measurements.Queries;
using WillEnergy.WebUI.Controllers.Common;

namespace WillEnergy.WebUI.Controllers
{
    public class SensorsController : ApiController
    {
        [HttpGet]
        public async Task<IList<MeasurementDto>> Get()
        {
            return await Bus.Send(new GetCurrentMeasurementsQuery());
        }

        [HttpGet("Worst")]
        public async Task<MeasurementDto> GetWorstMeasurement()
        {
            return await Bus.Send(new GetWorstSensorMeasurementQuery());
        }
    }
}
