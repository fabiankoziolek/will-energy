using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WillEnergy.Application.Forms.Commands;
using WillEnergy.WebUI.Controllers.Common;

namespace WillEnergy.WebUI.Controllers
{
    public class FormsController : ApiController
    {
        private readonly IMediator _mediator;

        public FormsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Submit(SubmitForm request)
        {
            var stream = await Bus.Send(request);
            stream.Position = 0;

            return File(stream, "application/octet-stream", "fileData.Filename.zip");
        }
    }
}
