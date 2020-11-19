using WillEnergy.Domain.Common.RichObjects;

namespace WillEnergy.Domain.ValueObjects.Identifiers
{
    public class SampleId : IntTypedId
    {
        public SampleId(int value)
            : base(value)
        {
        }

        public static implicit operator SampleId(int id)
            => new SampleId(id);
    }
}
