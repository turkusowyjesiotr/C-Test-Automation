using System;

namespace examproject.Utils
{
    public static class RandomUtil
    {
        private const int minimumIntRange = 5;
        private const int maximumIntRange = 30;

        public static string GetRandomString(int length)
        {
            string stringCharacters = "abcdefghijklmnopqrstuvwxyz";
            string randomString = "";
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int stringCharactersIndex = random.Next(stringCharacters.Length);
                randomString += stringCharacters[stringCharactersIndex];
            }
            return randomString;
        }

        public static int GetRandomInteger()
        {
            var random = new Random();
            return random.Next(minimumIntRange, maximumIntRange);
        }
    }
}
