using SystemDot.Core.Collections;
using SystemDot.Ioc;
using Gym.Domain.Accounts;

namespace Gym.Specifications.Steps
{
    using BoDi;
    using Gym.Infrastructure;
    using TechTalk.SpecFlow;

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

        [BeforeScenario]
        public void OnBeforeScenario()
        {
            DomainEventDispatcher.Reset();

            container.RegisterInstance<IDateTimeProvider, TestDateTimeProvider>();
            Domain.Bootstrapping.Bootstrapper.Bootstrap(container);

            container.ResolveMutipleTypes()
                .ThatImplementOpenType(typeof(ICommandHandler<>))
                .ForEach(handler => specFlowContainer.RegisterInstanceAs(handler));

            specFlowContainer.RegisterInstanceAs(container.Resolve<IDateTimeProvider>());
            specFlowContainer.RegisterInstanceAs(container.Resolve<Repository>());
        }
    }
}