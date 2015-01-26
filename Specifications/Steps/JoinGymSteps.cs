
namespace Gym.Specifications.Steps
{
    using System;
    using Gym.Domain;
    using Gym.Infrastructure;
    using Gym.Messages;
    using TechTalk.SpecFlow;
    using FluentAssertions;

    [Binding]
    public class JoinGymSteps
    {
        private readonly JoinGymCommandHandler joinGymCommandHandler;
        private readonly Repository repository;
        private Membership membership;

        public JoinGymSteps(Repository repository)
        {
            joinGymCommandHandler = new JoinGymCommandHandler(repository);
            this.repository = repository;
        }

        [When(@"I join the gym stating the following details:")]
        public void WhenIJoinTheGymStatingTheFollowingDetails(JoinGym command)
        {
            joinGymCommandHandler.Handle(command);
        }

        [Then(@"a gym membership should have been created with an id of (.*)")]
        public void ThenAGymMembershipShouldHaveBeenCreatedWithAnIdOf(int id)
        {
            membership = repository.GetById<Membership>(MembershipId.Parse(id));
            membership.Should().NotBeNull();
        }

        [Then(@"that membership should be for a member who was born on '(.*)'")]
        public void ThenThatMembershipShouldBeForAMemberWhoWasBornOn(DateTime dateOfBirth)
        {
            membership.DateOfBirth.Should().Be(dateOfBirth);
        }
        
        [StepArgumentTransformation]
        private JoinGym ConvertTableToJoinGymCommand(Table table)
        {
            return new JoinGym
            {
                Id = Int32.Parse(table.Rows[0][0]),
                DateOfBirth = DateTime.Parse(table.Rows[0][1])
            };
        }
    }
}
