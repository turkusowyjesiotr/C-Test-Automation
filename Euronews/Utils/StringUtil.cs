using System;
using System.Text;

namespace Euronews.Utils
{
    public static class StringUtil
    {
        public static string GetHrefFromBase64(string stringSource)
        {
            stringSource = DecodeBase64(stringSource);
            int start, end;
            string stringStart = "href=\"";
            string stringEnd = "\"";
            start = stringSource.IndexOf(stringStart, 0) + stringStart.Length;
            end = stringSource.IndexOf(stringEnd, start);
            return stringSource.Substring(start, end - start);
        }

        private static string DecodeBase64(string stringBase64)
        {
            var stringConverted = stringBase64.Replace('-', '+');
            var bytesData = Convert.FromBase64String(stringConverted);
            var resultString = Encoding.UTF8.GetString(bytesData);
            return resultString;
        }
    }
}
