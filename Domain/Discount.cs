using SystemDot.Core;

namespace Gym.Domain
{
    public class Discount : Equatable<Discount>
    {
        public static Discount Zero
        {
            get { return new Discount(0); }
        }

        public static Discount Parse(decimal value)
        {
            return new Discount(value);
        }

        public static Discount operator +(Discount left, Discount right)
        {
            return new Discount(left.value + right.value);
        }

        public static implicit operator decimal(Discount from)
        {
            return from.value;
        }

        readonly decimal value;

        Discount(decimal value)
        {
            this.value = value;
        }

        public override bool Equals(Discount other)
        {
            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}