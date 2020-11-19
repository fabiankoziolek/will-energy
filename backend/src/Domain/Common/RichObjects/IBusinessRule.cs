namespace WillEnergy.Domain.Common.RichObjects
{
    public interface IBusinessRule
    {
        bool IsBroken();
        string Message { get; }
    }
}
