using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillEnergy.Application.Samples.Queries;
using WillEnergy.Application.Samples.Queries.FindSamples;
using WillEnergy.Domain.ValueObjects.Identifiers;
using WillEnergy.WebUI.Controllers.Common;
using WillEnergy.WebUI.Controllers.Requests;

namespace WillEnergy.WebUI.Controllers
{
    public class SamplesController : ApiController
    {
        [HttpGet]
        public async Task<IList<SampleDto>> FindSelf()
        {
            return await Bus.Send(new FindSamplesQuery(UserId.Generate()));
        }

        [HttpPost]
        public async Task Add(SampleAddRequest request)
        {
            await Bus.Send(request.ToCommand(UserId.Generate(), string.Empty));
        }
    }
}
