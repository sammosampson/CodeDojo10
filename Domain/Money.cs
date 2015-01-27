namespace Gym.Domain
{
    using SystemDot.Core;

    public class Money : Equatable<Money>
    {
        public static Money Parse(decimal value)
        {
            return new Money(value);
        }

        public static implicit operator decimal(Money from)
        {
            return from.value;
        }

        public static Money operator *(Money money, Discount discount)
        {
            return new Money(money.value - (money.value * (discount / 100)));
        }

        private readonly decimal value;

        private Money(decimal value)
        {
            this.value = value;
        }

        public override bool Equals(Money other)
        {
            return other.value == value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}