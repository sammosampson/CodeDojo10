using Gym.Domain.Memberships;
using Gym.Infrastructure;
using Gym.Messages;

namespace Gym.Domain.Accounts
{
    public class MembershipFeeChangedHandler : IEventHandler<MembershipFeeChanged>
    {
        readonly Repository repository;

        public MembershipFeeChangedHandler(Repository repository)
        {
            this.repository = repository;
        }

        public void Handle(MembershipFeeChanged @event)
        {
            repository
                .GetById<Account>(MembershipId.Parse(@event.MembershipId))
                .Entries.ChangeMonthlyEntries(12, Money.Parse(@event.NewFee));
        }
    }
}