using BasicCachingSystem.Manager.Interfaces;
using BasicCachingSystem.Models;
using Microsoft.VisualBasic;
using System.Collections.Concurrent;

namespace BasicCachingSystem.Manager.Classes
{
    public class CacheManager : ICacheManager
    {
        private  ConcurrentDictionary<string, CacheItem> _cache { get; set; } = new ConcurrentDictionary<string, CacheItem>();

        public string Add(string key, object value, TimeSpan expiration)
        {
            if (_cache.ContainsKey(key) is false)
            {
                _cache.TryAdd(key, new CacheItem() { ExpirationTime = DateTime.Now + expiration, Key = key, Value = value });
                return "Added to cache.";
            }
            return "Key already in cache.";
        }
        public CacheItem? Get(string key)
        {
            if (_cache.ContainsKey(key))
            {
                return _cache[key];
            }
            return  null;
        }
        public bool Remove(string key)
        {
            var countBeforeDelete = _cache.Count;
            if (_cache.ContainsKey(key) is false)
            {
                return false;
            }
            _cache.TryRemove(key, out CacheItem? removedValue);
            var countAfterDelete = _cache.Count;
            return countAfterDelete < countBeforeDelete;
        }
        // cleans where cache time expired
        public string CleanUp()
        {
            var count = 0;
            foreach (var item in _cache)
            {
                if (item.Value.IsExpired())
                {
                    _cache.TryRemove(item.Key, out CacheItem? removedValue);
                    count++;
                }
            }
            return count > 0 ? $"Removed {count} expired items.": "No expired cache at the moment.";
        }
    }
}
