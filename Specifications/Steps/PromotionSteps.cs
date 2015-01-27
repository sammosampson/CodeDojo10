using Gym.Domain.Promotions;
using Gym.Messages;
using TechTalk.SpecFlow;

namespace Gym.Specifications.Steps
{
    [Binding]
    public class PromotionSteps
    {
        readonly SetupAgeBasedPromotionHandler handler;

        public PromotionSteps(SetupAgeBasedPromotionHandler handler)
        {
            this.handler = handler;
        }

        [Given(@"a promotion is setup for the over (.*)'s at a discount of (.*)%")]
        public void GivenAPromotionIsSetupForTheOverSAtADiscountOf(int age, decimal discount)
        {
            handler.Handle(new SetupAgeBasedPromotion
            {
                Age = age, 
                Discount = discount
            });
        }
    }
}