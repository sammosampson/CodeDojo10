namespace Gym.Domain
{
    using System;
    using Gym.Infrastructure;

    public class Membership : IdEqualityBase<Membership>
    {
        public DateTime DateOfBirth { get; private set; }

        public Membership(MembershipId id, DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
            Id = id;
        }
    }
}