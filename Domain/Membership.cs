namespace Gym.Domain
{
    using Gym.Infrastructure;

    public class Membership : IdEqualityBase<Membership>
    {
        public Membership(MembershipId id)
        {
            Id = id;
        }
    }
}