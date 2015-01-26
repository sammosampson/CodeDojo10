namespace Gym.Specifications.Steps
{
    using BoDi;
    using Gym.Infrastructure;
    using TechTalk.SpecFlow;

    [Binding]
    public class Bootstrapper
    {
        private readonly IObjectContainer specFlowContainer;

        private Bootstrapper(IObjectContainer specFlowContainer)
        {
            this.specFlowContainer = specFlowContainer;
        }

        [BeforeScenario]
        public void OnBeforeScenario()
        {
            specFlowContainer.RegisterTypeAs<Repository, Repository>();
        }
    }
}