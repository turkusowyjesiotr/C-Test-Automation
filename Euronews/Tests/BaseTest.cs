using NUnit.Framework;
using Aquality.Selenium.Browsers;
using Euronews.Models;
using Euronews.Utils;
using Euronews.Framework;

namespace Euronews.Tests
{
    public abstract class BaseTest
    {
        public static ConfigModel Config => JsonUtil.GetConfig();
        public static ClientSecret Secret => JsonUtil.GetClientSecretModel();
        public static TestDataModel TestData => JsonUtil.GetTestDataModel();
        public static Browser Browser;
        public static GmailApi Client;

        [SetUp]
        public void Setup()
        {
            var token = new TokenUtil(Secret, Config.Port);
            Client = new GmailApi(GmailEndpoints.MAIL, token.GetToken());
            Browser = AqualityServices.Browser;
            Browser.Maximize();
            Browser.GoTo(Config.PageUrl);
            Browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
        }
    }
}
