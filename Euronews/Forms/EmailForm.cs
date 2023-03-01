using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Euronews.Forms
{
    public class EmailForm : Form
    {
        private readonly ITextBox emailTextBox = ElementFactory.GetTextBox(By.XPath("//input[@type='email']"), "Subscription form -> Email TextBox");
        private readonly IButton submitButton = ElementFactory.GetButton(By.XPath("//input[@type='submit']"), "Subscription form -> Submit Button");
        public EmailForm() : base(By.Id("register-newsletters-form"), "Subscription form")
        {
        }

        public void EnterEmailAndSubmit(string email)
        {
            emailTextBox.ClearAndType(email);
            submitButton.WaitAndClick();
        }
    }
}
