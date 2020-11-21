using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WillEnergy.WebUI.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Bus => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
