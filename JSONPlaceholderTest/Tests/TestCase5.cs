using NUnit.Framework;
using System.Net;
using System.Text.Json;
using JSONPlaceholderTest.Models;
using System.Collections.Generic;
using JSONPlaceholderTest.Utils;
using JSONPlaceholderTest.Framework;

namespace JSONPlaceholderTest.Tests
{
    public class TestCase5 : BaseTest
    {        
        [Test]
        public void GetAllUsers()
        {
            var getAllUsersResponse = APIclient.GetAllUsers();
            var userTestData = JsonUtil.GetUserModel("user_id5.json");
            Assert.That(getAllUsersResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            Assert.That(APIclient.IsResponseExpectedType(getAllUsersResponse, ResponseType.JSON), "List is not JSON");
            var usersList = JsonSerializer.Deserialize<List<UserDataModel>>(getAllUsersResponse.Content);
            var userWithID5FromResponse = usersList.Find(user => user.id == 5);
            Assert.That(userTestData.IsEqual(userWithID5FromResponse), "User with ID 5 data is not matching test data");
        }
    }
}
