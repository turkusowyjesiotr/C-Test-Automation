using OpenQA.Selenium;
using Aquality.Selenium.Forms;

namespace Userinyerface.Forms.Pages
{
    public class PersonalDetailsPage : Form
    {
        public PersonalDetailsPage() : base(By.ClassName("personal-details"), "Personal Details Form")
        {
        }
    }
}
