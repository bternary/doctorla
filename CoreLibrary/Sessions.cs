using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace CoreLibrary
{
    public static class Session
    {

        public static void Set<T>(this ISession session, string key, T value) where T : class
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key) where T : class
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
        public static void Remove(this ISession session, string key)
        {
            session.Remove(key);
        }
    }
}
