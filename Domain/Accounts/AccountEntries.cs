using System.Collections;
using System.Collections.Generic;
using Gym.Infrastructure;

namespace Gym.Domain.Accounts
{
    public class AccountEntries : IEnumerable<AccountEntry>
    {
        readonly List<AccountEntry> entries;

        public AccountEntries()
        {
            entries = new List<AccountEntry>();
        }

        public void AddMonthlyEntries(int months, Money value, IDateTimeProvider dateTimeProvider)
        {
            for (int month = 1; month <= months; month++)
            {
                entries.Add(new AccountEntry(dateTimeProvider.GetCurrentDate().AddMonths(month), value));
            }
        }

        public IEnumerator<AccountEntry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ChangeMonthlyEntries(int months, Money value)
        {
            for (int month = 0; month < months; month++)
            {
                entries[month].Value = value;
            }
        }
    }
}