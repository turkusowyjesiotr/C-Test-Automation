using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Euronews.Models;


namespace Euronews.Utils
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

        public static TestDataModel GetTestDataModel()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/test_data.json");
            string jsonString = File.ReadAllText(jsonFile);
            var testData = JsonSerializer.Deserialize<TestDataModel>(jsonString);
            return testData;
        }

        public static ClientSecret GetClientSecretModel()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/client_secret.json");
            string jsonString = File.ReadAllText(jsonFile);
            var clientSecretModel = JsonSerializer.Deserialize<ClientSecretModel>(jsonString);
            return clientSecretModel.installed;
        }

        public static TokenModel GetTokenModel()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/client_token.json");
            string jsonString = File.ReadAllText(jsonFile);
            var tokenModel = JsonSerializer.Deserialize<TokenModel>(jsonString);
            return tokenModel;
        }

        public static List<Message> GetEmailsList(string json)
        {
            var messages = JsonSerializer.Deserialize<MessagesModel>(json);
            return messages.messages;
        }

        public static EmailModel GetEmailModel(string json)
        {
            var emailModel = JsonSerializer.Deserialize<EmailModel>(json);
            return emailModel;
        }

        public static void SaveTokenToFile(string jsonToSave, bool firstTime)
        {
            var tokenModel = JsonSerializer.Deserialize<TokenModel>(jsonToSave);
            tokenModel.expiration_date = DateTime.Now.AddSeconds(tokenModel.expires_in);
            if (!firstTime)
            {
                tokenModel.refresh_token = GetTokenModel().refresh_token;
            }
            string json = JsonSerializer.Serialize(tokenModel);
            File.WriteAllText("Resources/client_token.json", json);
        }

        public static string JsonToString(string file)
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources/{file}");
            string jsonString = File.ReadAllText(jsonFile);
            return jsonString;
        }

    }
}