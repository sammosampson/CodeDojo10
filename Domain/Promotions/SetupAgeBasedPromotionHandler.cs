using Gym.Infrastructure;
using Gym.Messages;

namespace Gym.Domain.Promotions
{
    public class SetupAgeBasedPromotionHandler : ICommandHandler<SetupAgeBasedPromotion>
    {
        readonly Repository repository;

        public SetupAgeBasedPromotionHandler(Repository repository)
        {
            this.repository = repository;
        }

        public void Handle(SetupAgeBasedPromotion command)
        {
            var list = repository.GetById<PromotionsList>(PromotionsListId.Value);
            list.Add(new AgeBasedPromotion(command.Age, Discount.Parse(command.Discount)));
        }
    }
}