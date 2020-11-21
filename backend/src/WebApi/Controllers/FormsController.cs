using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillEnergy.Application.Forms.Commands;
using WillEnergy.WebUI.Controllers.Common;

namespace WillEnergy.WebUI.Controllers
{
    public class FormsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult> Submit(SubmitForm request)
        {
            var stream = await Bus.Send(request);
            stream.Position = 0;

            return File(stream, "application/octet-stream", "Wniosek.zip");
        }
    }
}
