
namespace Gym.Specifications.Steps
{
    using System;
    using System.Threading.Tasks;
    using SystemDot.Bootstrapping;
    using SystemDot.Domain;
    using SystemDot.Domain.Bootstrapping;
    using SystemDot.Ioc;
    using SystemDot.RelationalDataStore.Bootstrapping;
    using SystemDot.RelationalDataStore.InMemory.Bootstrapping;
    using BoDi;
    using Gym.Domain;
    using Gym.Messages;
    using TechTalk.SpecFlow;
    using SystemDot.Domain.Commands;
    using SystemDot.RelationalDataStore.Repositories;
    using FluentAssertions;

    [Binding]
    public class JoinGymSteps
    {
        private readonly JoinGymCommandHandler joinGymCommandHandler;
        private readonly IRepository repository;
        private Membership membership;

        public JoinGymSteps(JoinGymCommandHandler joinGymCommandHandler, IRepository repository)
        {
            this.joinGymCommandHandler = joinGymCommandHandler;
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
            membership = repository.GetByIdAsync<Membership>(MembershipId.Parse(id)).Result;
            membership.Should().NotBeNull();
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

    [Binding]
    public class Bootstrapper
    {
        private readonly IObjectContainer specFlowContainer;
        private readonly IocContainer container;

        private Bootstrapper(IObjectContainer specFlowContainer)
        {
            this.specFlowContainer = specFlowContainer;
            container = new IocContainer();
        }

        async Task ConfigureSystemDot()
        {
            await Bootstrap.Application()
                .ResolveReferencesWith(container)
                .UseDomain().WithSimpleMessaging()
                .UseRelationalDataStore().PersistToMemory()
                .InitialiseAsync();
        }
    }
}
