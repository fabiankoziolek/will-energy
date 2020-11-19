using System;

namespace WillEnergy.Domain.Common.Auditability
{
    public interface ICreatableEntity
    {
        DateTimeOffset CreatedAt { get; }
    }
}
