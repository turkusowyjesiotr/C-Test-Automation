using System.Diagnostics;

namespace Euronews.ManualAuth
{
    public class LocalBrowser
    {
        private readonly string pathToBrowser = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

        public LocalBrowser(string URL)
        {
            Process.Start(pathToBrowser, URL.ToString());
        }
    }
}
