using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillEnergy.Application.Calculator.Queries;
using WillEnergy.Application.Calculator.Queries.CalculateCostsQuery;
using WillEnergy.Application.Common.Enums;
using WillEnergy.Domain.Core.Documents;
using WillEnergy.WebUI.Controllers.Common;

namespace WillEnergy.WebUI.Controllers
{
    public class CalculatorController : ApiController
    {
        [HttpGet]
        public async Task<CalculateCostsDto> Calculate([FromQuery] string heatingType, [FromQuery] int buildingArea)
        {
            return await Bus.Send(new CalculateCostsQuery(buildingArea, EnumUtils.GetEnum<HeatingType>(heatingType)));
        }
    }
}
