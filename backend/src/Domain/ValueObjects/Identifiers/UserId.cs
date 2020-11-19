using System;
using WillEnergy.Domain.Common.RichObjects;

namespace WillEnergy.Domain.ValueObjects.Identifiers
{
    public class UserId : GuidTypedId
    {
        public UserId(Guid value)
            : base(value)
        {
        }

        public UserId(string value)
            : base(Guid.Parse(value))
        {
        }

        public static UserId Generate()
        {
            return new UserId(Guid.NewGuid());
        }

        public static implicit operator UserId(Guid id)
            => new UserId(id);
    }
}
