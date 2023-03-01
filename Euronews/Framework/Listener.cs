using System.Net;

namespace Euronews.Framework
{
    public class Listener
    {
        private readonly string prefix = "http://localhost:8000/";
        public HttpListener listener;
        public Listener()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
        }

        public string ReceiveAccessCode()
        {
            listener.Start();            
            HttpListenerContext context = listener.GetContext();            
            HttpListenerRequest req = context.Request;
            var stringUrl = req.Url.OriginalString;            
            var equalsSignIndex = stringUrl.IndexOf("=") + 1;
            var ampersandIndex = stringUrl.IndexOf("&");
            int lengthToSlice = ampersandIndex - equalsSignIndex;
            string accessCode = stringUrl.Substring(equalsSignIndex, lengthToSlice);
            return accessCode;
        }
    }
}
