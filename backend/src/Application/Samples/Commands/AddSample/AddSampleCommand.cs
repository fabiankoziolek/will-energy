using WillEnergy.Application.Common.Bus;
using WillEnergy.Domain.Enums;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Application.Samples.Commands.AddSample
{
    public class AddSampleCommand : ICommand
    {
        public SampleType Type { get; }

        public UserId UserId { get; }

        public string Username { get; }

        public AddSampleCommand(SampleType type, UserId userId, string username)
        {
            Type = type;
            UserId = userId;
            Username = username;
        }
    }
}
