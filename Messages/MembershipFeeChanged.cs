namespace Gym.Messages
{
    public class MembershipFeeChanged
    {
        public int MembershipId { get; set; }
        public decimal NewFee { get; set; }
    }
}