using System;
using System.Collections.Generic;
using Gym.Domain.Memberships;
using Gym.Infrastructure;

namespace Gym.Domain.Promotions
{
    public class PromotionsList : AggregateRoot<PromotionsList>
    {
        readonly List<IPromotion> list;

        public PromotionsList() : base(PromotionsListId.Value)
        {
            list = new List<IPromotion>();
        }
        
        public void Add(IPromotion toAdd)
        {
            list.Add(toAdd);
        }

        public void ApplyPromotions(Membership toApplyTo, Action<Discount> onApplyTotalDiscount, IDateTimeProvider dateTimeProvider)
        {
            Discount discount = Discount.Zero;

            foreach (IPromotion promotion in list)
            {
                if(promotion.Applicable(toApplyTo, dateTimeProvider));
                {
                    discount = promotion.Discount + discount;
                }
            }

            if (discount == Discount.Zero)
            {
                return;
            }

            onApplyTotalDiscount(discount);
        }
    }
}