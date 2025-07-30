using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06_SeleniumAutomation
{
    public static class ConfigReader
    {
        public static string GetConfigValue(string key)
        {
            var json = File.ReadAllText("Resources/credentials.json");
            var jObject = JObject.Parse(json);
            return jObject[key]?.ToString();
        }
    }
}
