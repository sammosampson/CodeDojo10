using SystemDot.Core.Collections;
using SystemDot.Ioc;
using Gym.Domain.Accounts;
using Gym.Infrastructure;

namespace Gym.Domain.Bootstrapping
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<MembershipStartedHandler>()
                .ThatImplementOpenType(typeof(IEventHandler<>))
                .ByClass();

            container.ResolveMutipleTypes()
                .ThatImplementOpenType(typeof(IEventHandler<>))
                .ForEach(DomainEventDispatcher.RegisterHandler);
 
            container.RegisterMultipleTypes()
                .FromAssemblyOf<MembershipStartedHandler>()
                .ThatImplementOpenType(typeof(ICommandHandler<>))
                .ByInterface();

            container.Resolve<Initialiser>().Initialise();
        }
    }
}
