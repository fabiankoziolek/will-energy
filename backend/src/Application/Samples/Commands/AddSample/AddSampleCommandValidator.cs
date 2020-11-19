using FluentValidation;

namespace WillEnergy.Application.Samples.Commands.AddSample
{
    public class AddSampleCommandValidator : AbstractValidator<AddSampleCommand>
    {
        public AddSampleCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
