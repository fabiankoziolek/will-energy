using System;
using WillEnergy.Domain.Exceptions;

namespace WillEnergy.Domain.Common.RichObjects
{
    public abstract class Entity
    {
        public static string ErrorMessage(string message, string entityName, object key) =>
            $"{message}. Entity {entityName}(key={key}).";

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new DomainException(rule.Message);
            }
        }

        protected static bool TryRun(Action throwableAction)
        {
            try
            {
                throwableAction();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
