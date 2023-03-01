using NUnit.Framework;
using System.Net;
using System.Text.Json;
using JSONPlaceholderTest.Models;
using System.Collections.Generic;
using JSONPlaceholderTest.Framework;
using System.Linq;
using System;

namespace JSONPlaceholderTest.Tests
{
    public class TestCase1 : BaseTest
    {
        [Test]
        public void GetAllPosts()
        {
            var getAllPostsResponse = APIclient.GetAllPosts();
            var postsList = JsonSerializer.Deserialize<List<PostDataModel>>(getAllPostsResponse.Content);
            Assert.That(getAllPostsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            Assert.That(APIclient.IsResponseExpectedType(getAllPostsResponse, ResponseType.JSON), "List is not JSON");
            var postsListsSortedByID = postsList.OrderBy(post => post.id).ToList();
            Assert.IsTrue(postsListsSortedByID.SequenceEqual(postsList), "Posts are not in ascending order");            
        }
    }
}
