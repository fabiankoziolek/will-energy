using WillEnergy.Domain.Common.RichObjects;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Domain.Rules.Reservations
{
    public class OnlyActiveSampleCanBeCancelledRule : IBusinessRule
    {
        private readonly SampleId _id;
        private readonly bool _isDeleted;

        public OnlyActiveSampleCanBeCancelledRule(SampleId id, bool isDeleted)
        {
            _id = id;
            _isDeleted = isDeleted;
        }

        public bool IsBroken() => _isDeleted;
        public string Message => Entity.ErrorMessage("Sample is already cancelled", nameof(Sample), _id);
    }
}
