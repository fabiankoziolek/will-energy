using System;

namespace WillEnergy.Domain.Common.RichObjects
{
    public abstract class GuidTypedId : IEquatable<GuidTypedId>
    {
        public Guid Value { get; }

        protected GuidTypedId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidOperationException("Id value cannot be empty!");
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is GuidTypedId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(GuidTypedId other)
        {
            return Value == other?.Value;
        }

        public static bool operator ==(GuidTypedId obj1, GuidTypedId obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(GuidTypedId x, GuidTypedId y)
        {
            return !(x == y);
        }
    }
}
