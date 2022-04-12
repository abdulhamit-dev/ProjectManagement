using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectManagement.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private RedisServer _redisServer;

        public RedisCacheManager(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Add(string key, object data, int duration)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _redisServer.Database.StringSet(key, jsonData, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            if (IsAdd(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public object Get(string key)
        {
            if (IsAdd(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                var rv = JsonConvert.DeserializeObject(jsonData);
                return rv;
            }
            return default;
        }

        public bool IsAdd(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_redisServer) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _redisServer.Database.KeyDelete(key.ToString());
            }
        }

    }
}
