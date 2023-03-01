using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinyerface.Forms.Pages
{
    public class CookiesForm : Form
    {
        private readonly IButton _hideCookiesButton = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Not really')]"), "Hide cookies button");
        public CookiesForm() : base(By.ClassName("cookies"), "Cookies Form")
        {
        }

        public void AcceptCookies()
        {
            _hideCookiesButton.WaitAndClick();
        }

        public bool IsHidden()
        {
            return _hideCookiesButton.State.WaitForNotDisplayed();
        }
    }

}
