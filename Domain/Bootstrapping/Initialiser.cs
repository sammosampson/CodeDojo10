using Gym.Domain.Promotions;
using Gym.Infrastructure;

namespace Gym.Domain.Bootstrapping
{
    public class Initialiser
    {
        readonly Repository repository;

        public Initialiser(Repository repository)
        {
            this.repository = repository;
        }

        public void Initialise()
        {
            repository.Add(new PromotionsList());
        }
    }
}