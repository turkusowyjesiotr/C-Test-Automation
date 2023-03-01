using Userinyerface.Utils;

namespace Userinyerface.Models
{
    public class UserDataModel
    {   
        private const int MinimumPasswordLength = 10;
        private readonly string _password;
        private readonly string _email;
        private readonly string _domain;
        public UserDataModel(string password, string email, string domain)
        {
            _password = password;
            _email = email;
            _domain = domain;
        }
        public string Password
        {
            get { return _password; }
        }
        public string Email
        {
            get { return _email; }
        }
        public string Domain
        {
            get { return _domain; }
        }

        public static UserDataModel GenerateRandomUser()
        {
            return new UserDataModel(RandomUtil.GetRandomString(MinimumPasswordLength, true), RandomUtil.GetRandomString(), RandomUtil.GetRandomString());
        }
    }
}
