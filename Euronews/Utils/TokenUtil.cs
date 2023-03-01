using System;
using System.IO;
using Euronews.Models;
using Euronews.Framework;

namespace Euronews.Utils
{
    public class TokenUtil
    {
        private const string pathToToken = "Resources/client_token.json";

        public TokenUtil(ClientSecret secret, string port)
        {
            var token = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToToken);
            bool tokenExists = File.Exists(token);            
            if (!tokenExists)
            {
                ManualAuthorization.GetToken(secret, port);
            }
            else
            {
                var tokenModel = JsonUtil.GetTokenModel();
                var dateNow = DateTime.Now;
                var tokenExpirationDate = tokenModel.expiration_date;
                bool tokenIsValid = dateNow < tokenExpirationDate;
                if (!tokenIsValid)
                {
                    var tokenClient = new GmailToken(GmailEndpoints.TOKEN);
                    var tokenResponse = tokenClient.RefreshAccessToken(secret, tokenModel);
                    JsonUtil.SaveTokenToFile(tokenResponse.Content, false);
                }                
            }
        }

        public TokenModel GetToken()
        {
            var tokenModel = JsonUtil.GetTokenModel();
            return tokenModel;
        }
    }
}
