using NUnit.Framework;
using Aquality.Selenium.Browsers;
using examproject.Utils;
using examproject.Pages;
using System;
using System.Net;
using System.Text.Json;
using examproject.Models;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace examproject.Tests
{
    public class TestCaseVariant2 : BaseTest
    {
        [Test]
        public void Test1()
        {            
            RestResponse getTokenResponse = Client.GetToken(TestData.Variant);
            string token = getTokenResponse.Content;
            Assert.Multiple(() =>
            {
                Assert.That(getTokenResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Token response status is not OK");
                Assert.That(token, Is.Not.Null.Or.Not.Empty, "Token wasn't generated");
            });

            Browser.GoTo(urlAuthentication);
            Browser.WaitForPageToLoad();
            var cookie = CookieUtil.CreateTokenCookie(token);
            var allProjectsPage = new AllProjectsPage();
            Browser.Driver.Manage().Cookies.AddCookie(cookie);
            Browser.Refresh();
            Assert.That(allProjectsPage.IsCorrectVersionDisplayed(TestData.Variant), "Displayed variant number is incorrect");

            allProjectsPage.ClickProjectButton("Nexage");
            var nexageProjectPage = new ProjectPage("Nexage");
            nexageProjectPage.State.WaitForDisplayed();
            List<string> visibleTestsNames = nexageProjectPage.GetAllTestsNames();
            RestResponse getAllTestsResponse = Client.GetTestsJson(TestData.NexageProjectId, 10);
            var allTestsList = JsonSerializer.Deserialize<List<TestModel>>(getAllTestsResponse.Content);
            var sortedTestsList = allTestsList.OrderByDescending(test => test.startTime).ToList();
            var sortedTestNames = new List<string>();
            for (int i = 0; i < visibleTestsNames.Count; i++)
            {
                sortedTestNames.Add(sortedTestsList[i].name);
            }
            CollectionAssert.AreEqual(visibleTestsNames, sortedTestNames, "Tests returned by API do not correspond with tests visible on the page");

            Browser.GoBack();
            Browser.WaitForPageToLoad();
            allProjectsPage.ClickAddButton();
            Browser.Tabs().SwitchToLastTab();
            var addProjectForm = new AddProjectForm();
            addProjectForm.State.WaitForDisplayed();
            var projectName = RandomUtil.GetRandomString(RandomUtil.GetRandomInteger());
            addProjectForm.AddProject(projectName);
            Assert.That(addProjectForm.IsSuccessfullyAdded(projectName), "Alert with message about successful saving didn't appear");
            Browser.Tabs().CloseTab();
            Browser.Tabs().SwitchToTab(0);
            Browser.Refresh();
            Assert.That(allProjectsPage.IsProjectAdded(projectName), "Added project is not on the list");

            allProjectsPage.ClickProjectButton(projectName);
            var testProjectPage = new ProjectPage(projectName);
            var byteScreenshot = Browser.GetScreenshot();
            var base64screenshot = Convert.ToBase64String(byteScreenshot);
            var testLog = StringUtil.ReadTestLogToString();
            var SID = DateTime.Now.ToString();
            var testName = projectName + ".test";
            var methodName = testName + ".method";
            var env = "X";
            Client.AddTestToProject(SID, projectName, testName, methodName, env, base64screenshot, testLog);
            var testProjectTestName = testProjectPage.GetTestName();
            Assert.That(testName, Is.EqualTo(testProjectTestName), "Tests wasn't added correctly to the project page");
        }
    }
}