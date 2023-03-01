using RestSharp;

namespace Euronews.Framework
{
    public abstract class ApiClient
    {        
        protected static RestClient client;
        protected ApiClient(string URL)
        {
            client = new RestClient(URL);
        }        

        protected RestResponse Get(string path)
        {
            var request = new RestRequest(path, Method.Get);
            var response = client.Execute(request);
            return response;
        }

        protected RestResponse Post(string path, string jsonToSend)
        {
            var request = new RestRequest(path, Method.Post);
            request.AddParameter(ResponseType.JSON, jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            return response;
        }        
    }
}


