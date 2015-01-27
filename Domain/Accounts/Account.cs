using Gym.Domain.Memberships;
using Gym.Infrastructure;

namespace Gym.Domain.Accounts
{
    public class Account : AggregateRoot<Account>
    {
        readonly AccountEntries entries;

        public MembershipId Id { get; private set; }

        public Account(MembershipId id) : base(id)
        {
            Id = id;
            entries = new AccountEntries();
        }

        public AccountEntries Entries
        {
            get { return entries; }
        }
    }
}