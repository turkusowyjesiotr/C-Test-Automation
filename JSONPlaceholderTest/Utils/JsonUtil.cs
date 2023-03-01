using System;
using System.IO;
using System.Text.Json;
using JSONPlaceholderTest.Models;


namespace JSONPlaceholderTest.Utils
{
    public class JsonUtil
    {
        public static ConfigModel GetConfig()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/config.json");
            string jsonString = File.ReadAllText(jsonFile);
            var config = JsonSerializer.Deserialize<ConfigModel>(jsonString);
            return config;

        }
        public static UserDataModel GetUserModel(string file)
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources/{file}");
            string jsonString = File.ReadAllText(jsonFile);
            var user = JsonSerializer.Deserialize<UserDataModel>(jsonString);
            return user;
        }

    }
}