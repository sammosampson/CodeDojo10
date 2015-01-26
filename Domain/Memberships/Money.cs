namespace Gym.Domain.Memberships
{
    using SystemDot.Core;

    public class Money : Equatable<Money>
    {
        public static Money Parse(decimal value)
        {
            return new Money(value);
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