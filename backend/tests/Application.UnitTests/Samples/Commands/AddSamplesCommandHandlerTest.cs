using System.Threading.Tasks;
using NUnit.Framework;
using WillEnergy.Application.Samples.Commands.AddSample;
using WillEnergy.Domain.Enums;

namespace WillEnergy.Application.UnitTests.Samples.Commands
{
    public class AddSamplesCommandHandlerTest : RequestTestBase
    {
        [Test]
        public async Task ShouldAddSingleReservation()
        {
            var request = new AddSampleCommand(SampleType.Type1, TestUserId(), "Rafał");
            // var handler = new AddSampleCommandHandler(new SamplesWriteRepository(await InitializedContext()));
            var handler = new AddSampleCommandHandler();

            await handler.Handle(request);
        }

        // [Test]
        // public async Task ShouldThrowExceptionWhenNotExistingOffice()
        // {
        //     var request = new AddSampleCommand(SampleType.Type1, TestUserId(), "Rafał");
        //     var handler = new AddSampleCommandHandler();
        //
        //     handler.Invoking(x => x.Handle(request)).Should()
        //         .Throw<NotFoundException>();
        // }
    }
}
