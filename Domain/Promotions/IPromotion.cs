using Gym.Domain.Memberships;
using Gym.Infrastructure;

namespace Gym.Domain.Promotions
{
    public interface IPromotion
    {
        bool Applicable(Membership toApplyTo, IDateTimeProvider dateTimeProvider);
        Discount Discount { get; }
    }
}