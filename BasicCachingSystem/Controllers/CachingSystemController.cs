using BasicCachingSystem.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicCachingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CachingSystemController : Controller
    {
        private readonly ICacheManager _cacheManager;

        public CachingSystemController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        [HttpGet("Get")]
        public IActionResult Get(string key)
        {
            var cacheItem = _cacheManager.Get(key);
            if(cacheItem is null)
            {
                return NotFound("Item not found!");
            }
            return Ok(cacheItem);
        }

        [HttpPost("Add")]
        public IActionResult Add(string key, object value, int time) 
        {
            var addToCache = _cacheManager.Add(key,value,TimeSpan.FromMinutes(time));
            return Ok(addToCache);
        }

        [HttpPost("Remove")]
        public IActionResult Remove(string key)
        {
            var addToCache = _cacheManager.Remove(key);
            return Ok(addToCache);
        }

        [HttpPost("CleanUp")]
        public IActionResult CleanUp(string key)
        {
            _cacheManager.CleanUp();
            return Ok();
        }
    }
}
