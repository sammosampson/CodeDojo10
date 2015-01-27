using System;
using System.Linq;
using FluentAssertions;
using Gym.Domain;
using Gym.Domain.Accounts;
using Gym.Domain.Memberships;
using Gym.Infrastructure;
using TechTalk.SpecFlow;

namespace Gym.Specifications.Steps
{
    [Binding]
    public class AccountSteps
    {
        private readonly Repository repository;

        public AccountSteps(Repository repository)
        {
            this.repository = repository;
        }

        [Then(@"the account for the membership (.*) should have the following debits:")]
        public void ThenTheAccountForTheMembershipShouldHaveTheFollowingDebits(int id, Table table)
        {
            var account = repository.GetById<Account>(MembershipId.Parse(id));

            for(int index = 0; index < table.RowCount; index++)
            {
                AccountEntry accountEntry = account.Entries.ElementAt(index);
                accountEntry.ExpectedPaymentOn.Should().Be(DateTime.Parse(table.Rows[index][0]));
                accountEntry.Value.Should().Be(Money.Parse(Decimal.Parse(table.Rows[index][1])));
            }

            account.Should().NotBeNull();
        }
    }
}
