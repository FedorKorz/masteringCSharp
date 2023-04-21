using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Utilities
{
    internal class JSONReader
    {
        public static String grabData(String key)
        {
            var dataJson = File.ReadAllText("C:\\Users\\user\\source\\repos\\masteringC#\\TestFramework\\testData\\testData.json");
            var jsonObject =  JToken.Parse(dataJson);
            return jsonObject.SelectToken(key).Value<String>();
        }

        public static String[] grabDataArray(String key)
        {
            var dataJson = File.ReadAllText("C:\\Users\\user\\source\\repos\\masteringC#\\TestFramework\\testData\\testData.json");
            var jsonObject = JToken.Parse(dataJson);
            return jsonObject.SelectTokens(key).Values<string>().ToArray();
        }
    }
}
