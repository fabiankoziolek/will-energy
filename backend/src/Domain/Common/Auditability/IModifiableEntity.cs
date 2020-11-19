using System;

namespace WillEnergy.Domain.Common.Auditability
{
    public interface IModifiableEntity
    {
        DateTimeOffset? ModifiedAt { get; }
    }
}
