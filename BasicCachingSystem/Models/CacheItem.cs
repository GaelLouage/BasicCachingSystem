namespace BasicCachingSystem.Models
{
    public class CacheItem
    {
        public string Key { get; set; } 
        public object Value { get; set; }
        public DateTime ExpirationTime { get; set; } 

        public bool IsExpired()
        {
            return DateTime.Now > ExpirationTime;
        }
    }
}
