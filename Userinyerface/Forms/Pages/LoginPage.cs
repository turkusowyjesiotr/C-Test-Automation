using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Userinyerface.Forms.Pages
{
    public class LoginPage : Form
    {
        private readonly ILabel _timer = ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'timer')]"), "Timer");
        private readonly ITextBox _passwordTextBox = ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Choose Password')]"), "Password TextBox");
        private readonly ITextBox _emailTextBox = ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Your email')]"), "Email TextBox");
        private readonly ITextBox _domainTextBox = ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Domain')]"), "Domain TextBox");
        private readonly IButton _dropdownOpener = ElementFactory.GetButton(By.ClassName("dropdown__opener"), "Dropdown Opener Button");
        private readonly By _domainsLocator = By.XPath("//div[contains(@class, 'dropdown__list-item') and not(contains(text(), 'other'))]");
        private readonly ICheckBox _doNotAcceptCheckBox = ElementFactory.GetCheckBox(By.ClassName("checkbox__box"), "I do not accept CheckBox");
        private readonly ILink _nextLink = ElementFactory.GetLink(By.XPath("//a[contains(@class, 'button--secondary') and contains(text(), 'Next')]"), "Next link button");
        
        public LoginPage() : base(By.ClassName("login-form"), "Login Form")
        {
        }

        private void FillPassword(string password)
        {
            _passwordTextBox.ClearAndType(password);
        }

        private void FillEmail(string email)
        {
            _emailTextBox.ClearAndType(email);
        }

        private void FillDomain(string domain)
        {
            _domainTextBox.ClearAndType(domain);
        }

        private void ChooseRandomDomain()
        {
            var random = new Random();
            _dropdownOpener.Click();
            IList<IButton> dropdownDomainsToChoose = ElementFactory.FindElements<IButton>(_domainsLocator, "Domain Button");
            var randomDomain = random.Next(0, dropdownDomainsToChoose.Count);
            dropdownDomainsToChoose[randomDomain].Click();  
        }

        private void ChooseDomain(string domain)
        {
            _dropdownOpener.Click();
            IList<IButton> dropdownDomainsToChoose = ElementFactory.FindElements<IButton>(_domainsLocator, "Domain Button");
            foreach (IButton domainToChoose in dropdownDomainsToChoose)
            {
                if (domain == domainToChoose.GetText())
                {
                    int index = dropdownDomainsToChoose.IndexOf(domainToChoose);
                    dropdownDomainsToChoose[index].Click();
                    break;
                }
            }
        }

        public void InputLoginCredentials(string password, string email, string domainName, string domainAfterDot = "")
        {
            FillPassword(password);
            FillEmail(email);
            FillDomain(domainName);
            if (string.IsNullOrEmpty(domainAfterDot))
            {
                ChooseRandomDomain();
            } else
            {
                ChooseDomain(domainAfterDot);
            }            
        }

        public void AcceptTerms()
        {
            _doNotAcceptCheckBox.Click();
        }

        public void ClickNext()
        {
            _nextLink.Click();
        }

        public string GetTime()
        {
            return _timer.GetText();
        }
    }
}
