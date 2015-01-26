namespace Gym.Infrastructure
{
    using SystemDot.Core;

    public abstract class IdEqualityBase<T> : Equatable<T> where T : IdEqualityBase<T>
    {
        public string Id { get; set; }

        public override bool Equals(T other)
        {
            return Id.Equals(other.Id);
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}