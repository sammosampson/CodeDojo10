namespace Gym.Domain.Memberships
{
    using Gym.Infrastructure;

    public class Membership : IdEqualityBase<Membership>
    {
        public static Membership Start(MembershipId id, DateOfBirth dateOfBirth)
        {
            return new Membership(id, dateOfBirth);
        }

        public DateOfBirth DateOfBirth { get; private set; }
        public Money Fee { get; private set; }

        private Membership(MembershipId id, DateOfBirth dateOfBirth)
        {
            Id = id;
            DateOfBirth = dateOfBirth;
            Fee = Money.Parse(50M);
        }
    }
}