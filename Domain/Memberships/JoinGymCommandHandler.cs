namespace Gym.Domain.Memberships
{
    using Gym.Infrastructure;
    using Gym.Messages;

    public class JoinGymCommandHandler : ICommandHandler<JoinGym>
    {
        private readonly Repository repository;

        public JoinGymCommandHandler(Repository repository)
        {
            this.repository = repository;
        }

        public void Handle(JoinGym command)
        {
            repository.Add(
                Membership.Start(
                    MembershipId.Parse(command.Id), 
                    DateOfBirth.Parse(command.DateOfBirth)));
        }
    }
}