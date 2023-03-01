using NUnit.Framework;
using JSONPlaceholderTest.Models;
using JSONPlaceholderTest.Utils;
using JSONPlaceholderTest.Framework;

namespace JSONPlaceholderTest
{
    public abstract class BaseTest
    {
        private static ConfigModel Config => JsonUtil.GetConfig();        
        public static APIClient APIclient;

        [SetUp]
        public void Setup()
        {
            APIclient = APIClient.GetAPIClient(Config.PageUrl);            
        }      
    }
}