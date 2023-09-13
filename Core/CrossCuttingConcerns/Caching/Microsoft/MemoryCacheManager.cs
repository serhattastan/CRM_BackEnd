using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern : Varolan bir sistemi kendi sistemine göre ayarlamak.
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {            
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var memoryCacheType = _memoryCache.GetType();
            var entriesCollection = memoryCacheType.GetField("_entriesCollection", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(_memoryCache);

            if (entriesCollection is not null)
            {
                var cacheCollectionValues = (entriesCollection.GetType().GetProperty("Values", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(entriesCollection) as ICollection)?.Cast<object>();

                if (cacheCollectionValues is not null)
                {
                    var keysToRemove = cacheCollectionValues.Where(item => regex.IsMatch(item?.ToString())).ToList();
                    keysToRemove.ForEach(key => _memoryCache.Remove(key));
                }
            }
        }
    }
}
