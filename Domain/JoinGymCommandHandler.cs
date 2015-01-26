namespace Gym.Domain
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
            repository.Add(new Membership(MembershipId.Parse(command.Id), command.DateOfBirth));
        }
    }
}