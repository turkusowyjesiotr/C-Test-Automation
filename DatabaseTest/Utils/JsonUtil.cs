using System;
using System.IO;
using System.Text.Json;
using DatabaseTest.Models;

namespace DatabaseTest.Utils
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

        public static AuthorTableModel GetAuthorModel()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/author.json");
            string jsonString = File.ReadAllText(jsonFile);
            var authorModel = JsonSerializer.Deserialize<AuthorTableModel>(jsonString);
            return authorModel;
        }

        public static ProjectTableModel GetProjectModel()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/project_info.json");
            string jsonString = File.ReadAllText(jsonFile);
            var projectModel = JsonSerializer.Deserialize<ProjectTableModel>(jsonString);
            return projectModel;
        }
    }
}
