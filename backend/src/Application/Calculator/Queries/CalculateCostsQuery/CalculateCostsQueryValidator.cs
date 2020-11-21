using FluentValidation;

namespace WillEnergy.Application.Calculator.Queries.CalculateCostsQuery
{
    public class CalculateCostsQueryValidator : AbstractValidator<CalculateCostsQuery>
    {
        public CalculateCostsQueryValidator()
        {
            RuleFor(x => x.BuildingArea).GreaterThan(0).NotEmpty();
        }
    }
}
