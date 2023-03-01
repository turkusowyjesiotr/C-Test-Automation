using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Forms;

namespace Userinyerface.Forms.Pages
{
    public class HelpForm : Form
    {
        private readonly IButton _sendToBottomButton = ElementFactory.GetButton(By.XPath("//button//span[contains(text(), 'to bottom')]"), "Send to bottom button");
        public HelpForm() : base(By.XPath("//div[@class='help-form']"), "Help Form")
        {
        }

        public void HideHelpForm()
        {
            _sendToBottomButton.WaitAndClick();
        }

        public bool IsHidden()
        {
            return _sendToBottomButton.State.WaitForNotDisplayed();
        }
    }
}
