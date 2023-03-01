using RestSharp;
using Euronews.Models;

namespace Euronews.Framework
{
    public class GmailToken : ApiClient
    {
        private readonly string path = string.Empty;
        public GmailToken(string URL) : base(URL)
        {
        }

        public RestResponse GetAccessCode(string jsonToSend, ClientSecret secret, string port)
        {            
            var request = new RestRequest(path, Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter(ResponseType.JSON, jsonToSend, ParameterType.RequestBody);
            request.AddParameter("scope", GmailConsts.SCOPE);
            request.AddParameter("response_type", GmailConsts.CODE);
            request.AddParameter("access_type", GmailConsts.OFFLINE);
            request.AddParameter("redirect_uri", secret.redirect_uris[0] + port);
            request.AddParameter("client_id", secret.client_id);            
            var response = client.Execute(request);
            return response;
        }

        public RestResponse GetAccessToken(string code, ClientSecret secret, string port)
        {            
            var request = new RestRequest(path, Method.Post);
            request.AddHeader("Content-Type", ResponseType.URL_ENCODED);            
            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", secret.redirect_uris[0] + port);
            request.AddParameter("client_id", secret.client_id);
            request.AddParameter("client_secret", secret.client_secret);
            request.AddParameter("grant_type", GmailConsts.AUTHORIZATION_CODE);
            var response = client.Execute(request);            
            return response;
        }

        public RestResponse RefreshAccessToken(ClientSecret secret, TokenModel token)
        {
            var request = new RestRequest(path, Method.Post);
            request.AddHeader("Content-Type", ResponseType.URL_ENCODED);
            request.AddParameter("client_id", secret.client_id);
            request.AddParameter("client_secret", secret.client_secret);
            request.AddParameter("refresh_token", token.refresh_token);
            request.AddParameter("grant_type", GmailConsts.REFRESH_TOKEN);
            var response = client.Execute(request);
            return response;
        }
    }
}
