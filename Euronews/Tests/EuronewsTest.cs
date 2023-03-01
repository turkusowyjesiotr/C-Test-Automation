using NUnit.Framework;
using Euronews.Forms;
using Euronews.Utils;
using Aquality.Selenium.Browsers;

namespace Euronews.Tests
{
    public class EuronewsTest : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.State.WaitForDisplayed(), "Main page of Euronews is not open");
            mainPage.AcceptCookies();

            mainPage.ClickNewslettersLink();
            var newslettersPage = new NewslettersPage();
            Assert.IsTrue(newslettersPage.State.WaitForDisplayed(), "Newsletters page is not open");

            var chosenNewsletterIndex = newslettersPage.SelectRandomNewsletter();
            var emailForm = new EmailForm();
            Assert.IsTrue(emailForm.State.WaitForDisplayed(), "Email form didn't appear");
            
            emailForm.EnterEmailAndSubmit(TestData.Email);            
            var confirmationEmailId = EmailUtil.WaitForEmail(Client, "euronews", 2, 10);
            Assert.IsNotEmpty(confirmationEmailId, "Email with request to confirm subscription wasn't received");
            
            var confirmationEmailResponse = Client.GetEmail(confirmationEmailId);
            var confirmationEmailModel = JsonUtil.GetEmailModel(confirmationEmailResponse.Content);
            var confirmationPageUrl = StringUtil.GetHrefFromBase64(confirmationEmailModel.payload.parts[0].body.data);
            Browser.GoTo(confirmationPageUrl);
            var confirmationPage = new ConfirmationPage();
            Assert.IsTrue(confirmationPage.State.WaitForDisplayed(), "Confirmation page is not open");

            confirmationPage.ClickBackToTheSiteButton();
            Assert.IsTrue(mainPage.State.WaitForDisplayed(), "Main page of Euronews is not open");

            mainPage.ClickNewslettersLink();
            newslettersPage.State.WaitForDisplayed();
            newslettersPage.SelectNewsletterPreview(chosenNewsletterIndex);
            Assert.IsTrue(newslettersPage.PreviewIsOpen(), "Preview of required plan is not open");

            var unsubLink = newslettersPage.GetUnsubLink(Browser.Driver);
            Browser.GoTo(unsubLink);
            var unsubPage = new UnsubPage();
            Assert.IsTrue(unsubPage.State.WaitForDisplayed(), "Unsubscribe page is not open");

            unsubPage.EnterEmailAndUnsubscribe(TestData.Email);
            Assert.IsTrue(unsubPage.IsUnsubscribed(), "Message about subscription cancellation didn't appear");

            var unsubEmail = EmailUtil.WaitForEmail(Client, "euronews", 0.5f, 15);
            Assert.IsEmpty(unsubEmail, "Email about cancelling subscription has arrived");           
        }
    }
}