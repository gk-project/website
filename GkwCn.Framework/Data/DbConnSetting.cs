using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Data
{
    public sealed class DbConnSetting
    {
        private static IDictionary<string, string> connDicts = new Dictionary<string, string>();

        public static void AddConnKey(string key)
        {
            connDicts.Add(key, ConfigurationManager.ConnectionStrings[key].ConnectionString);
        }

        public static void RemoveConnKey(string key)
        {
            connDicts.Remove(key);
        }

        public static string DefaultConnectionKey { get; set; }

        public static string GetConnection(string key)
        {
            if (connDicts.ContainsKey(key))
                return connDicts[key];
            return string.Empty;
        }

        public static string GetConnection()
        {
            return connDicts[DefaultConnectionKey];
        }
    }
}
