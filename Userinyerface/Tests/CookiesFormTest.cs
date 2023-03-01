using NUnit.Framework;
using Userinyerface.Forms.Pages;

namespace Userinyerface.Tests
{
    public class CookiesFormTest : BaseTest
    {
        [Test]
        public void TestHideCookiesForm()
        {
            var homePage = new HomePage();
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not  open");

            homePage.ClickHereLink();
            var cookiesForm = new CookiesForm();
            cookiesForm.AcceptCookies();
            Assert.IsTrue(cookiesForm.IsHidden(), "Cookies form is not hidden");
            
        }
    }
}
