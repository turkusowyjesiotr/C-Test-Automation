using NUnit.Framework;
using Userinyerface.Forms.Pages;

namespace Userinyerface.Tests
{
    public class TimerTest : BaseTest
    {
        [Test]
        public void TestTimer()
        {
            var homePage = new HomePage();
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not  open");

            homePage.ClickHereLink();
            var loginPage = new LoginPage();
            Assert.AreEqual(loginPage.GetTime(), "00:00:00", "Timer does not start on 00:00:00");

        }
    }
}