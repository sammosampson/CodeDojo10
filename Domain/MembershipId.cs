namespace Gym.Domain
{
    using System;

    public class MembershipId 
    {
        public static implicit operator string(MembershipId from)
        {
            return string.Empty;
        }

        public static string Parse(int id)
        {
            throw new NotImplementedException();
        }
    }
}