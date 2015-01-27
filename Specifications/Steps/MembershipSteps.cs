
namespace Gym.Specifications.Steps
{
    using System;
    using Domain;
    using Domain.Memberships;
    using Infrastructure;
    using Messages;
    using TechTalk.SpecFlow;
    using FluentAssertions;

    [Binding]
    public class MembershipSteps
    {
        private readonly JoinGymHandler joinGymHandler;
        private readonly Repository repository;
        private Membership membership;

        public MembershipSteps(Repository repository, JoinGymHandler joinGymHandler)
        {
            this.joinGymHandler = joinGymHandler;
            this.repository = repository;
        }

        [When(@"I join the gym stating the following details:")]
        public void WhenIJoinTheGymStatingTheFollowingDetails(JoinGym command)
        {
            joinGymHandler.Handle(command);
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
            membership.DateOfBirth.Should().Be(DateOfBirth.Parse(dateOfBirth));
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
