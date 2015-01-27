
using Gym.Domain.Promotions;

namespace Gym.Domain.Memberships
{
    using Messages;
    using Infrastructure;

    public class Membership : AggregateRoot<Membership>
    {
        readonly static Money StandardFee = Money.Parse(50M);

        public static Membership Start(MembershipId id, DateOfBirth dateOfBirth)
        {
            return new Membership(id, dateOfBirth);
        }

        public MembershipId Id { get; set; }

        public DateOfBirth DateOfBirth { get; private set; }

        private Membership(MembershipId id, DateOfBirth dateOfBirth)
            : base(id)
        {
            Id = id;
            DateOfBirth = dateOfBirth;
            RaiseEvent(new MembershipStarted { MembershipId = id, InitialFee = StandardFee });
        }

        public void ApplyPromotions(PromotionsList promotions, IDateTimeProvider dateTimeProvider)
        {
            promotions.ApplyPromotions(this, ChangeMembershipFee, dateTimeProvider);
        }

        void ChangeMembershipFee(Discount discount)
        {
            RaiseEvent(new MembershipFeeChanged { MembershipId = Id, NewFee = StandardFee * discount });
        }
    }
}