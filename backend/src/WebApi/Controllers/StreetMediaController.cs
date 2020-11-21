using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WillEnergy.Application.Streets;
using WillEnergy.Application.Streets.Queries;
using WillEnergy.WebUI.Controllers.Common;

namespace WillEnergy.WebUI.Controllers
{
    public class StreetMediaController : ApiController
    {
        [HttpGet]
        public async Task<StreetMediaDto> StreetMedia([FromQuery]string streetName)
        {
            return await Bus.Send(new StreetMediaQuery(streetName));
        }
    }
}
