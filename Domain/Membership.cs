namespace Gym.Domain
{
    using System;
    using Gym.Infrastructure;

    public class Membership : IdEqualityBase<Membership>
    {
        public static Membership Start(MembershipId id, DateOfBirth dateOfBirth)
        {
            return new Membership(id, dateOfBirth);
        }

        public DateOfBirth DateOfBirth { get; private set; }

        private Membership(MembershipId id, DateOfBirth dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
            Id = id;
        }
    }
}