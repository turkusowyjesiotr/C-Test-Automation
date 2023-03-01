using NUnit.Framework;
using System.Net;
using System.Text.Json;
using JSONPlaceholderTest.Models;
using JSONPlaceholderTest.Utils;

namespace JSONPlaceholderTest.Tests
{
    public class TestCase6 : BaseTest
    {
        [Test]
        public void GetUserWithID5()
        {
            var userTestData = JsonUtil.GetUserModel("user_id5.json");
            var getUserWithID5Response = APIclient.GetUser(5);
            Assert.That(getUserWithID5Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            var userFromResponse = JsonSerializer.Deserialize<UserDataModel>(getUserWithID5Response.Content);
            Assert.That(userTestData.IsEqual(userFromResponse), "Retrieved data is not matching data from previous step");
        }
    }
}
