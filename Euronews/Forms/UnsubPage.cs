using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Euronews.Forms
{
    public class UnsubPage : Form
    {
        private readonly ITextBox emailAddressTextBox = ElementFactory.GetTextBox(By.Id("email"), "Unsub Form -> Email address TextBox");
        private readonly IButton confirmUnsubButton = ElementFactory.GetButton(By.XPath("//button[contains(@type, 'submit')]"), "Unsub Form -> Confirm unsubscription Button");
        private readonly ILabel unsubscribedText = ElementFactory.GetLabel(By.XPath("//strong[contains(text(), 'unsubscribed')]"), "Unsub Form -> You are unsubscribed text");
        public UnsubPage() : base(By.Id("email"), "Unsub Form")
        {
        }

        public void EnterEmailAndUnsubscribe(string email)
        {
            emailAddressTextBox.ClearAndType(email);
            confirmUnsubButton.WaitAndClick();
        }

        public bool IsUnsubscribed()
        {
            return unsubscribedText.State.WaitForDisplayed();
        }
    }
}
