using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using System.Collections.Generic;
using Userinyerface.Utils;

namespace Userinyerface.Forms.Pages
{
    public class InterestsPage : Form
    {
        private readonly IButton _uploadAvatarButton = ElementFactory.GetButton(By.XPath("//a[contains(@class, 'upload-button')]"), "Upload avatar link");
        private readonly ICheckBox _unselectAllCheckBox = ElementFactory.GetCheckBox(By.XPath("//div[contains(@class, 'interests-list__item') and .//span[contains(text(), 'Unselect all')]]//span[@class = 'checkbox small']"), "Unselect all CheckBox");
        private readonly IList<ICheckBox> _interestsCheckBoxes = ElementFactory.FindElements<ICheckBox>(By.XPath("//div[contains(@class, 'interests-list__item') and not(.//span[contains(text(), 'elect')])]//span[@class = 'checkbox small']"), "Interests CheckBoxes");
        private readonly IButton _nextButton = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Next')]"), "Next Button");
        public InterestsPage() : base(By.ClassName("avatar-and-interests"), "Interests Form")
        {
        }

        public void ChooseRandomInterests(int interestsAmount)
        {   
            _unselectAllCheckBox.WaitAndClick();
            var listIndexes = RandomUtil.GetRandomIntegers(interestsAmount, 0, _interestsCheckBoxes.Count, false);
            foreach (int interest in listIndexes)
            {
                _interestsCheckBoxes[interest].WaitAndClick();
            }
        }

        public void UploadAvatarImage()
        {            
            _uploadAvatarButton.WaitAndClick();
        }

        public void ClickNext()
        {
            _nextButton.WaitAndClick();
        }
    }
}
