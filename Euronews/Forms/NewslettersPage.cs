using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using System.Collections.Generic;
using Euronews.Utils;
using System;

namespace Euronews.Forms
{
    public class NewslettersPage : Form
    {
        private readonly IList<ILabel> chooseThisNewsletterButtonList = ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'p-8') and not(.//h2[contains(text(), 'Special')])]//label[contains(@class, 'unchecked-label')]"), "Newsletter Form -> Choose this newsletter Button");
        private readonly IList<ILink> previewList = ElementFactory.FindElements<ILink>(By.XPath("//div[contains(@class, 'bg-white') and contains(@class, 'shadow-lg')]//a"), "Newsletter Form -> See previews Link");
        private readonly ILabel iFrame = ElementFactory.GetLabel(By.XPath("//iframe"), "Preview iframe");
        private readonly ILabel iframeClose = ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'w-full') and contains(@class, 'text-center')]//a"), "Preview iframe -> Close Button");
        private readonly ILabel unsubscribeNewsletter = ElementFactory.GetLabel(By.XPath("//a[contains(text(), 'unsubscribe')]"), "Unsubscribe");

        public NewslettersPage() : base(By.Id("newsletters-form"), "Newsletters Form")
        {
        }

        public void SelectNewsletter(int index)
        {
            chooseThisNewsletterButtonList[index].Click();
        }

        public int SelectRandomNewsletter()
        {
            var index = RandomUtil.GetRandomInteger(0, chooseThisNewsletterButtonList.Count - 1);
            SelectNewsletter(index);
            return index;
        }

        public void SelectNewsletterPreview(int index)
        {
            previewList[index].Click();            
        }

        private WebElement GetPreviewFrame()
        {            
            return iFrame.GetElement(TimeSpan.FromSeconds(30));
        }

        public bool PreviewIsOpen()
        {
            return iframeClose.State.WaitForDisplayed();
        }
        public string GetUnsubLink(WebDriver driver)
        {
            var iframe = GetPreviewFrame();
            driver.SwitchTo().Frame(iframe);
            var unsubLink = unsubscribeNewsletter.GetAttribute("href");
            driver.SwitchTo().DefaultContent();
            return unsubLink;
        }
    }
}
