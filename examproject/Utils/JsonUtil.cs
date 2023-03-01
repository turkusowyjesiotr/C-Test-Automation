using examproject.Models;
using System;
using System.IO;
using System.Text.Json;

namespace examproject.Utils
{
    public class JsonUtil
    {
        public static ConfigModel GetConfig()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/config.json");
            string jsonString = File.ReadAllText(jsonFile);
            var configModel = JsonSerializer.Deserialize<ConfigModel>(jsonString);
            return configModel;
        }

        public static TestDataModel GetTestDataModel()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/test_data.json");
            string jsonString = File.ReadAllText(jsonFile);
            var testDataModel = JsonSerializer.Deserialize<TestDataModel>(jsonString);
            return testDataModel;
        }

        public static bool IsValidJson(string jsonToValidate)
        {
            if (jsonToValidate == null)
            {
                return false;
            }

            try
            {
                JsonDocument.Parse(jsonToValidate);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }

        }
    }
}
