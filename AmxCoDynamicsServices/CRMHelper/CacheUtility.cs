using System;
using System.Web;

namespace AmxDynamicsServices
{
    public static class CacheUtility
    {
        public static void SetValueToCache(string cacheKey, object savedItem, TimeSpan cacheTimeSpan)// DateTime absoluteExpiration)
        {
            if (IsAvailableInCache(cacheKey))
            {
                HttpRuntime.Cache.Remove(cacheKey);
            }
            HttpRuntime.Cache.Add(cacheKey, savedItem, null, System.Web.Caching.Cache.NoAbsoluteExpiration, cacheTimeSpan, System.Web.Caching.CacheItemPriority.Default, null);
        }

        public static T GetValueFromCache<T>(string cacheKey) where T : class
        {
            return HttpRuntime.Cache[cacheKey] as T;
        }

        public static void RemoveValueFromCache(string cacheKey)
        {
            HttpRuntime.Cache.Remove(cacheKey);
        }

        public static bool IsAvailableInCache(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey] != null;
        }
    }
}