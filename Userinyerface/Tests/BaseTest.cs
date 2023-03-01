using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Userinyerface.Utils;
using Userinyerface.Models;

namespace Userinyerface.Tests
{
    public abstract class BaseTest
    {
        private static Browser _browser;
        private static ConfigModel Config => JsonUtil.GetConfig();

        [SetUp]
        public void Setup()
        {
            _browser = AqualityServices.Browser;
            _browser.Maximize();
            _browser.GoTo(Config.PageUrl);
            _browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            _browser.Quit();
        }
    }
}