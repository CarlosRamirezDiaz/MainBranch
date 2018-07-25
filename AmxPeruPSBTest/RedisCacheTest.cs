using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmxPeruPSBActivities.ActivitiesClaroESB;
using AmxPeruPSBWorkflows.ClaroESB;
using System.Threading;
using System.Collections.Generic;
using System.Activities;
using StackExchange.Redis;
using System.Linq;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class RedisCacheTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = this.GetDataFromDataBase();
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return ConnectionMultiplexer.Connect("localhost:6379");
            }
        }

        public Dictionary<string, string> GetDataFromDataBase(string sPattern = "*")
        {
            int dbName = 4; //or 0, 1, 2
            Dictionary<string, string> dicKeyValue = new Dictionary<string, string>();
            var keys = Connection.GetServer("localhost:6379").Keys(dbName, pattern: sPattern);
            //string[] keysArr = keys.Select(key => (string)key).ToArray();

            foreach (var key in keys)
            {
                dicKeyValue.Add(key, GetFromDB(dbName, key));
            }

            return dicKeyValue;
        }

        public string GetFromDB(int dbName, RedisKey key)
        {
            var db = Connection.GetDatabase(dbName);
            if (db.KeyType(key) == RedisType.String)
                return db.StringGet(key);
            else if (db.KeyType(key) == RedisType.Hash)
                return "hash value";
            else
                return string.Empty;
        }
    }
}