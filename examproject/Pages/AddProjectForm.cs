using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace examproject.Pages
{
    public class AddProjectForm : Form
    {
        private readonly ITextBox enterProjectNameTextBox = ElementFactory.GetTextBox(By.XPath("//input[@id='projectName']"), "Add project form -> enter project name text box");
        private readonly IButton saveProjectButton = ElementFactory.GetButton(By.XPath("//button[contains(@type, 'submit')]"), "Add project form -> Save project button");
        private readonly ILabel successAlert = ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'alert-success')]"), "Add project form -> Success alert");

        public AddProjectForm() : base(By.Id("addProjectForm"), "Add project form")
        {
        }

        public void AddProject(string projectName)
        {
            enterProjectNameTextBox.ClearAndType(projectName);
            saveProjectButton.WaitAndClick();
        }
        public bool IsSuccessfullyAdded(string projectName)
        {
            return successAlert.Text.Contains(projectName);
        }        
    }
}
