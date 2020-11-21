using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WillEnergy.WebUI.Controllers.Common;
using WillEnergy.WebUI.Controllers.Requests;

namespace WillEnergy.WebUI.Controllers
{
    public class ImportFromExcelController : ApiController
    {
        [HttpPost]
        public async Task ImportGasConnections([FromBody]ImportGasConnectionsFromExcelRequest request)
        {
            await Bus.Send(request.ToCommand(request.GasFilePath, request.HeatFilePath));
        }
    }
}
