using SystemDot.Messaging.Simple;

namespace Gym.Infrastructure
{
    public static class DomainEventDispatcher
    {
        static readonly Dispatcher Dispatcher = new Dispatcher();  

        public static void DispatchEvent<T>(T @event)
        {
            Dispatcher.Send(@event);
        }

        public static void Reset()
        {
            Dispatcher.Reset();
        }

        public static void RegisterHandler(object toRegister)
        {
            Dispatcher.RegisterHandler(toRegister);
        }
    }
}