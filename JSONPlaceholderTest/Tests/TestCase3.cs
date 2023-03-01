using NUnit.Framework;
using System.Net;

namespace JSONPlaceholderTest.Tests
{
    public class TestCase3 : BaseTest
    {
        [Test]
        public void GetPostWithID150()
        {
            var getPostWithID150Response = APIclient.GetPost(150);
            Assert.That(getPostWithID150Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code is not 404");
            Assert.That(getPostWithID150Response.Content == "{}", "Response body is not empty");
        }
    }
}
