using examproject.Models;
using examproject.Utils;
using examproject.Framework;
using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace examproject.Tests
{
    public abstract class BaseTest
    {
        public static Browser Browser;
        public static ConfigModel Config => JsonUtil.GetConfig();
        public static TestDataModel TestData => JsonUtil.GetTestDataModel();
        public static ApiClient Client;
        public static string applicationUrl;
        public static string urlAuthentication;

        [SetUp]
        public void Setup()
        {
            applicationUrl = $"http://{Config.Url}:{Config.Port}";
            urlAuthentication = $"http://{Config.Username}:{Config.Password}@{Config.Url}:{Config.Port}/web";
            Client = ApiClient.GetApiClient($"{applicationUrl}/api");
            Browser = AqualityServices.Browser;
            Browser.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
        }
    }
}
