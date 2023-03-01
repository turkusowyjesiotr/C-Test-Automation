using OpenQA.Selenium;

namespace examproject.Utils
{
    public static class CookieUtil
    {
        public static Cookie CreateCookie(string parameter, string value)
        {
            var cookie = new Cookie(parameter, value);
            return cookie;
        }

        public static Cookie CreateTokenCookie(string value)
        {
            return CreateCookie("token", value);
        }
    }
}
