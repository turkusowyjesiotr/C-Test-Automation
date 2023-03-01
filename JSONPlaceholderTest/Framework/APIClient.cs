using RestSharp;
using JSONPlaceholderTest.JsonPlaceholderAPI;

namespace JSONPlaceholderTest.Framework
{
    public class APIClient
    {
        private static APIClient _instance;        
        public static RestClient client;
        private APIClient(string URL) 
        {
            client = new RestClient(URL);
        }

        public static APIClient GetAPIClient(string URL)
        {
            if (_instance == null)
            {
                _instance = new APIClient(URL);
            }
            return _instance;
        }

        private RestResponse Get(string path)
        {
            var request = new RestRequest(path, Method.Get);
            var response = client.Execute(request);
            return response;
        }

        private RestResponse Post(string path, string jsonToSend)
        {
            var request = new RestRequest(path, Method.Post);
            request.AddParameter(ResponseType.JSON, jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            return response;
        }

        public RestResponse GetPost(int id)
        {
            return Get($"{APIEndpoints.POSTS}/{id}");
        }

        public RestResponse GetAllPosts()
        {
            return Get(APIEndpoints.POSTS);
        }

        public RestResponse GetUser(int id)
        {
            return Get($"{APIEndpoints.USERS}/{id}");
        }

        public RestResponse GetAllUsers()
        {
            return Get(APIEndpoints.USERS);
        }

        public RestResponse CreatePost(string jsonToPost)
        {
            return Post(APIEndpoints.POSTS, jsonToPost);
        }
        
        public bool IsResponseExpectedType(RestResponse response, string type)
        {            
            return response.ContentType.Equals(type);            
        }
    }

}
