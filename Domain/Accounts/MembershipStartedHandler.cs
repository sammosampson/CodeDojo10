using Gym.Domain.Memberships;
using Gym.Infrastructure;
using Gym.Messages;

namespace Gym.Domain.Accounts
{
    public class MembershipStartedHandler : IEventHandler<MembershipStarted>
    {
        readonly Repository repository;
        readonly IDateTimeProvider dateTimeProvider;

        public MembershipStartedHandler(Repository repository, IDateTimeProvider dateTimeProvider)
        {
            this.repository = repository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Handle(MembershipStarted @event)
        {
            var account = new Account(MembershipId.Parse(@event.MembershipId));
            account.Entries.AddMonthlyEntries(12, Money.Parse(@event.InitialFee), dateTimeProvider);
            repository.Add(account);
        }
    }
}