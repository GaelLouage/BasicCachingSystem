using BasicCachingSystem.Models;
using System.Collections.Concurrent;

namespace BasicCachingSystem.Manager.Interfaces
{
    public interface ICacheManager
    {
        string Add(string key, object value, TimeSpan expiration);
        string CleanUp();
        CacheItem? Get(string key);
        bool Remove(string key);
    }
}