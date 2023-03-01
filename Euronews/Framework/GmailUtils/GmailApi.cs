using Euronews.Models;
using RestSharp;

namespace Euronews.Framework
{
    public class GmailApi : ApiClient
    {
        private readonly TokenModel token;
        public GmailApi(string URL, TokenModel token) : base(URL)
        {
            this.token = token;
        }

        public RestResponse GetAllEmails(string domain)
        {
            var path = GmailEndpoints.MESSAGES;
            var request = new RestRequest(path, Method.Get);
            request.AddHeader("Authorization", $"Bearer {token.access_token}");
            request.AddParameter("q", $"from:{domain}");
            var response = client.Execute(request);
            return response;
        }

        public RestResponse GetEmail(string id)
        {
            var path = $"{GmailEndpoints.MESSAGES}/{id}";
            var request = new RestRequest(path, Method.Get);
            request.AddHeader("Authorization", $"Bearer {token.access_token}");
            var response = client.Execute(request);
            return response;
        }
    }
}
