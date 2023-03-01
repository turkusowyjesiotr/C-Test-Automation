using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Euronews.Forms
{
    public class ConfirmationPage : Form
    {
        private readonly IButton confirmationButton = ElementFactory.GetButton(By.XPath("//a[contains(@href, '//www.euronews.com')]//span[contains(text(), 'Back to the site')]"), "Confirmation Form -> Back to the site Button");
        public ConfirmationPage() : base(By.XPath("//a[contains(@href, '//www.euronews.com')]//span[contains(text(), 'Back to the site')]"), "Confirmation Button")
        {
        }

        public void ClickBackToTheSiteButton()
        {
            confirmationButton.WaitAndClick();
        }
    }
}
