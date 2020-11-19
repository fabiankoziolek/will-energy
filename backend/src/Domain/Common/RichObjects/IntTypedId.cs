using System;

namespace WillEnergy.Domain.Common.RichObjects
{
    public abstract class IntTypedId : IEquatable<IntTypedId>
    {
        public int Value { get; }

        protected IntTypedId(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is IntTypedId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(IntTypedId other)
        {
            return Value == other?.Value;
        }

        public static bool operator ==(IntTypedId obj1, IntTypedId obj2)
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

        public static bool operator !=(IntTypedId obj1, IntTypedId obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
