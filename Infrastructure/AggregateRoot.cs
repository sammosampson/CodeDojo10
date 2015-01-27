namespace Gym.Infrastructure
{
    using SystemDot.Core;

    public abstract class AggregateRoot<T> : Equatable<T> where T : AggregateRoot<T>
    {
        protected AggregateRoot(string id)
        {
            RawId = id;
        }

        internal string RawId { get; private set; }

        public override bool Equals(T other)
        {
            return RawId.Equals(other.RawId);
        }
        
        public override int GetHashCode()
        {
            return RawId.GetHashCode();
        }

        protected void RaiseEvent<TEvent>(TEvent @event)
        {
            DomainEventDispatcher.DispatchEvent(@event);
        }
    }
}