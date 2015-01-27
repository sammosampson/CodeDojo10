using Gym.Domain.Promotions;

namespace Gym.Domain.Memberships
{
    using Gym.Infrastructure;
    using Gym.Messages;

    public class JoinGymHandler : ICommandHandler<JoinGym>
    {
        private readonly Repository repository;
        readonly IDateTimeProvider dateTimeProvider;

        public JoinGymHandler(Repository repository, IDateTimeProvider dateTimeProvider)
        {
            this.repository = repository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Handle(JoinGym command)
        {
            Membership membership = Membership.Start(MembershipId.Parse(command.Id), DateOfBirth.Parse(command.DateOfBirth));
            membership.ApplyPromotions(repository.GetById<PromotionsList>(PromotionsListId.Value), dateTimeProvider);
            repository.Add(membership);
        }
    }
}