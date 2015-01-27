namespace Gym.Infrastructure
{
    public interface IEventHandler<in TEvent>
    {
        void Handle(TEvent @event);
    }
}