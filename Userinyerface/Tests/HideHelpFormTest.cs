using NUnit.Framework;
using Userinyerface.Forms.Pages;

namespace Userinyerface.Tests
{
    public class HideHelpFormTest : BaseTest
    {
        [Test]
        public void TestHideHelpForm()
        {
            var homePage = new HomePage();
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not  open");

            homePage.ClickHereLink();
            var helpForm = new HelpForm();
            helpForm.HideHelpForm();
            Assert.IsTrue(helpForm.IsHidden(), "Form content is not hidden");

        }
    }
}
