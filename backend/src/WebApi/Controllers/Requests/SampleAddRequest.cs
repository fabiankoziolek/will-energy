using WillEnergy.Application.Common.Enums;
using WillEnergy.Application.Samples.Commands.AddSample;
using WillEnergy.Domain.Enums;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.WebUI.Controllers.Requests
{
    public class SampleAddRequest
    {
        public string Type { get; set; }

        public AddSampleCommand ToCommand(UserId userId, string username)
        {
            return new AddSampleCommand(EnumUtils.GetEnum<SampleType>(Type), userId, username);
        }
    }
}
