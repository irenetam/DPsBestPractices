using System.Collections.Concurrent;

namespace Singleton.Caching
{
    public sealed class SingletonCache : IMyCache
    {
        private ConcurrentDictionary<object, object> concurrentDictionary = new ConcurrentDictionary<object, object>();
        private static readonly SingletonCache singletonInstance = new SingletonCache();
        private SingletonCache() { }
        public static SingletonCache GetInstance()
        {
            return singletonInstance;
        }
        public bool Add(object key, object value)
        {
            return concurrentDictionary.TryAdd(key, value);
        }

        public bool AddOrUpdate(object key, object value)
        {
            if (concurrentDictionary.ContainsKey(key))
            {
                concurrentDictionary.TryRemove(key, out object removedValue);
            }

            return concurrentDictionary.TryAdd(key, value);
        }

        public void Clear()
        {
            concurrentDictionary.Clear();
        }

        public object Get(object key)
        {
            if (concurrentDictionary.ContainsKey(key))
            {
                return concurrentDictionary[key];
            }
            return null;
        }

        public bool Remove(object key)
        {
            return concurrentDictionary.TryRemove(key, out object value);
        }
    }
}
