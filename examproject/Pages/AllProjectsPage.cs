using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace examproject.Pages
{
    public class AllProjectsPage : Form
    {
        private readonly ILabel versionLabel = ElementFactory.GetLabel(By.XPath("//footer//span"), "Footer -> Version number");
        private readonly ILabel addProjectButton = ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'panel-heading')]//a"), "Projects list -> Heading with Add button");
        private ILabel ProjectLabel(string projectName) => ElementFactory.GetLabel(By.XPath($"//a[contains(text(), '{projectName}')]"), $"Project {projectName} button");
        public AllProjectsPage() : base(By.ClassName("panel"), "All Projects Page")
        {
        }

        public bool IsCorrectVersionDisplayed(string versionNumber)
        {
            return versionLabel.Text.Contains(versionNumber);
        }

        public void ClickAddButton()
        {
            addProjectButton.WaitAndClick();
        }
        public bool IsProjectAdded(string projectName)
        {
            return ProjectLabel(projectName).State.WaitForDisplayed();
        }

        public void ClickProjectButton(string projectName)
        {
            ProjectLabel(projectName).WaitAndClick();
        }
    }
}
