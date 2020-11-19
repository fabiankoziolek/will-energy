using System.Threading.Tasks;
using MediatR;
using WillEnergy.Application.Common.Bus;

namespace WillEnergy.Application.Samples.Commands.AddSample
{
    public class AddSampleCommandHandler : CommandHandler<AddSampleCommand>
    {
        public override Task<Unit> Handle(AddSampleCommand request)
        {
            // var sample = await _sampleWriteRepository.FindX(...);

            // if (xyz == null)
            // {
            //     throw new NotFoundException(nameof(Sample), request.xxx);
            // }

            // domain methods

            // await _sampleWriteRepo.SaveChanges();

            return Unit.Task;
        }
    }
}
