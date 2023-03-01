using NUnit.Framework;
using System.Net;
using System.Text.Json;
using JSONPlaceholderTest.Models;

namespace JSONPlaceholderTest.Tests
{
    public class TestCase2 : BaseTest
    {
        [Test]
        public void GetPostWithID99()
        {
            var getPostWithID99Response = APIclient.GetPost(99);
            Assert.That(getPostWithID99Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            var userModel = JsonSerializer.Deserialize<PostDataModel>(getPostWithID99Response.Content);
            Assert.That(userModel.userId == 10, "User ID is not 10");
            Assert.That(userModel.id == 99, "Post ID is not 99");
            Assert.That(userModel.title != string.Empty, "Post title is empty");
            Assert.That(userModel.body != string.Empty, "Post body is empty");
        }
    }
}
