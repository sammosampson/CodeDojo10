namespace Gym.Infrastructure
{
    using System.Collections.Concurrent;
    using System.Linq;

    public class Repository
    {
        private readonly ConcurrentDictionary<object, object> entities;

        public Repository()
        {
            entities = new ConcurrentDictionary<object, object>();
        }

        public void Add<T>(T toAdd) where T : IdEqualityBase<T>
        {
            entities.TryAdd(toAdd, toAdd);
        }

        private IQueryable<T> Query<T>() where T : IdEqualityBase<T>
        {
            return entities.Values.OfType<T>().AsQueryable();
        }

        public T GetById<T>(string id) where T : IdEqualityBase<T>
        {
            return Query<T>().Single(t => t.Id == id);
        }
    }
}