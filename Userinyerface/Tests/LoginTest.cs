using NUnit.Framework;
using Userinyerface.Forms.Pages;
using Userinyerface.Models;
using Userinyerface.Utils;

namespace Userinyerface.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void TestLogin()
        {
            var homePage = new HomePage();
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not open");

            homePage.ClickHereLink();
            var loginPage = new LoginPage();            
            Assert.IsTrue(loginPage.State.WaitForDisplayed(), "Login card is not open");

            var userDataModel = UserDataModel.GenerateRandomUser();
            loginPage.InputLoginCredentials(userDataModel.Password, userDataModel.Email, userDataModel.Domain);
            loginPage.AcceptTerms();
            loginPage.ClickNext();
            var interestsPage = new InterestsPage();
            Assert.IsTrue(interestsPage.State.WaitForDisplayed(), "Interests card is not open");

            interestsPage.ChooseRandomInterests(3);
            interestsPage.UploadAvatarImage();
            WindowsFileExplorerHandler.UploadImage();
            interestsPage.ClickNext();
            var personalDetailsPage = new PersonalDetailsPage();
            Assert.IsTrue(personalDetailsPage.State.WaitForDisplayed(), "Personal details page is not open");

        }

    }
}
