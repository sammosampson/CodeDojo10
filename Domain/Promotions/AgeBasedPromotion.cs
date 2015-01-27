using Gym.Domain.Memberships;
using Gym.Infrastructure;

namespace Gym.Domain.Promotions
{
    public class AgeBasedPromotion : IPromotion
    {
        readonly int age;

        public Discount Discount { get; private set; }

        public AgeBasedPromotion(int age, Discount discount)
        {
            this.age = age;
            Discount = discount;
        }

        public bool Applicable(Membership toApplyTo, IDateTimeProvider dateTimeProvider)
        {
            return toApplyTo.DateOfBirth.CalculateAgeInYears(dateTimeProvider) >= 65;
        }
    }
}