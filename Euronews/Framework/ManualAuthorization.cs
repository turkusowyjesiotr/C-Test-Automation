using Euronews.Models;
using Euronews.Utils;
using Euronews.ManualAuth;

namespace Euronews.Framework
{
    public static class ManualAuthorization
    {
        public static void GetToken(ClientSecret secret, string port)
        {
            var clientAuth = new GmailToken(GmailEndpoints.AUTH);
            var listener = new Listener();
            var jsonToSend = JsonUtil.JsonToString("client_secret.json");
            var authResponse = clientAuth.GetAccessCode(jsonToSend, secret, port);
            var authResponseUrl = authResponse.ResponseUri.ToString();
            var localBrowser = new LocalBrowser(authResponseUrl);
            var accessCode = listener.ReceiveAccessCode();
            var clientToken = new GmailToken(GmailEndpoints.TOKEN);
            var tokenResponse = clientToken.GetAccessToken(accessCode, secret, port);            
            JsonUtil.SaveTokenToFile(tokenResponse.Content, true);
        }      

    }
}
