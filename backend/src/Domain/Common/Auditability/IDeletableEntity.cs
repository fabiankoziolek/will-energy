namespace WillEnergy.Domain.Common.Auditability
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; }
    }
}
