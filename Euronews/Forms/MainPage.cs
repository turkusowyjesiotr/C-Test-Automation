using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Euronews.Forms
{
    public class MainPage : Form
    {
        private readonly ILink newslettersLink = ElementFactory.GetLink(By.XPath("//a[@href='/newsletters']"), "Header -> Newsletters Link");
        private readonly IButton cookiesButton = ElementFactory.GetButton(By.Id("didomi-notice-agree-button"), "Cookies -> Agree and close");
        public MainPage() : base(By.Id("js-header"), "Euronews Header")
        {
        }

        public void ClickNewslettersLink()
        {
            newslettersLink.Click();
        }

        public void AcceptCookies()
        {
            cookiesButton.WaitAndClick();
        }
    }
}
