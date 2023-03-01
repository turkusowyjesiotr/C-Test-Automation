using System;
using System.Collections.Generic;

namespace JSONPlaceholderTest.Utils
{
    public static class RandomUtil
    {
        private const int minimumWordLength = 5;
        private const int maximumWordLength = 20;
        private const int minimumIntRange = 1;
        private const int maximumIntRange = 30;
        
        public static string GetRandomString(int length)
        {
            string stringCharacters = "abcdefghijklmnopqrstuvwxyz";
            string randomString = "";
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int stringCharactersIndex = random.Next(stringCharacters.Length);
                randomString = randomString + stringCharacters[stringCharactersIndex];
            }
            return randomString;
        }

        public static int GetRandomInteger()
        {
            var random = new Random();
            return random.Next(minimumIntRange, maximumIntRange);
        }

        public static string GetRandomSentence(int wordCount)
        {
            var random = new Random();            
            var words = new List<string>();

            for (int i = 0; i < wordCount; i++)
            {
                int length = random.Next(minimumWordLength, maximumWordLength);
                string word = GetRandomString(length);
                words.Add(word);
            }
            var randomSentence = String.Join(" ", words);
            return randomSentence;
        }
    }
}
