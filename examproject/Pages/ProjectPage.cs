using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using System.Collections.Generic;

namespace examproject.Pages
{
    public class ProjectPage : Form
    {
        private readonly ILabel testTable = ElementFactory.GetLabel(By.XPath("//table[@class='table']"), "Table with all tests -> Link with test name");
        private readonly By testName = By.XPath("//a[contains(@href, 'testInfo')]");

        public ProjectPage(string projectName) : base(By.Id("allTests"), $"Project {projectName} page")
        {
        }
        public string GetTestName()
        {
            var names = new List<string>();
            var timeout = System.TimeSpan.FromMinutes(1);
            var element = testTable.FindChildElement<ILink>(testName, "Test name");            
            element.State.WaitForDisplayed(timeout);
            return element.Text;          
        }
        public List<string> GetAllTestsNames()
        {
            var names = new List<string>();
            var table = testTable.GetElement();
            var links = table.FindElements(testName);
            foreach (IWebElement element in links)
            {
                names.Add(element.Text);
            }
            return names;
        }
    }
}
