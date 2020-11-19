using System;
using WillEnergy.Domain.Common.RichObjects;

namespace WillEnergy.Domain.Exceptions
{
  public class DomainException : Exception
  {
    public DomainException(string message)
      : base(message)
    {
    }

    public DomainException(string message, string entityName, object key)
        : base(Entity.ErrorMessage(message, entityName, key))
    {
    }
  }
}
