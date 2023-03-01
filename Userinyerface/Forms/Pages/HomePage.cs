using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Forms;

namespace Userinyerface.Forms.Pages
{
    public class HomePage : Form
    {
        private readonly ILink _hereLink = ElementFactory.GetLink(By.XPath("//a[contains(@href, 'game.html')]"), "HERE Link");

        public HomePage() : base(By.XPath("//button[contains(@class, 'start__button')]"), "Home Page")
        { 
        }

        public void ClickHereLink()
        {
            _hereLink.Click();
        }
    }
}
