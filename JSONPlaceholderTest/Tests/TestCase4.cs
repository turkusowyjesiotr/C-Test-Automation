using NUnit.Framework;
using System.Net;
using System.Text.Json;
using JSONPlaceholderTest.Models;
using JSONPlaceholderTest.Utils;

namespace JSONPlaceholderTest.Tests
{
    public class TestCase4 : BaseTest
    {
        [Test]
        public void CreatePost()
        {
            var userToPost = new PostDataModel
            {
                userId = 1,
                title = RandomUtil.GetRandomSentence(RandomUtil.GetRandomInteger()),
                body = RandomUtil.GetRandomSentence(RandomUtil.GetRandomInteger())
            };
            string jsonString = JsonSerializer.Serialize(userToPost);
            var postRequestResponse = APIclient.CreatePost(jsonString);
            Assert.That(postRequestResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code is not 201");
            var userCreated = JsonSerializer.Deserialize<PostDataModel>(postRequestResponse.Content);
            Assert.That(userToPost.userId == userCreated.userId, "User IDs are not matching");
            Assert.That(userToPost.title == userCreated.title, "Posts titles are not matching");
            Assert.That(userToPost.body == userCreated.body, "Posts bodies are not matching");
            Assert.That(userCreated.id == 101, "Response does not contain ID");
        }
    }
}
