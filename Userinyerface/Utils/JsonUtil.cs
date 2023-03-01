using System;
using System.IO;
using System.Text.Json;
using Userinyerface.Models;


namespace Userinyerface.Utils
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
    }
}
