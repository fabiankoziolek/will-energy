using FluentValidation;

namespace WillEnergy.Application.Samples.Queries.FindSamples
{
    public class FindSamplesQueryValidator : AbstractValidator<FindSamplesQuery>
    {
        public FindSamplesQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
