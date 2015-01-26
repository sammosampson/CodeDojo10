namespace Gym.Domain.Memberships
{
    using System.Globalization;

    public class MembershipId 
    {
        private readonly int id;

        private MembershipId(int id)
        {
            this.id = id;
        }

        public static implicit operator string(MembershipId from)
        {
            return from.id.ToString(CultureInfo.InvariantCulture);
        }

        public static MembershipId Parse(int id)
        {
            return new MembershipId(id);
        }
    }
}