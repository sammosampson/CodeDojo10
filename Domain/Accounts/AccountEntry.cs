using System;

namespace Gym.Domain.Accounts
{
    public class AccountEntry
    {
        public AccountEntry(DateTime expectedPaymentOn, Money value)
        {
            Value = value;
            ExpectedPaymentOn = expectedPaymentOn;
        }

        public DateTime ExpectedPaymentOn { get; private set; }

        public Money Value { get; internal set; }
    }
}