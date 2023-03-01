using System;
using System.Collections.Generic;

namespace Userinyerface.Utils
{
    public static class RandomUtil
    {
        private const int minimumStringLength = 6;
        
        public static string GetRandomString(int minLength = minimumStringLength, bool withUppercase = false)
        {
            string stringCharacters = "abcdefghijklmnopqrstuvwxyz";
            string stringNumbers = "0123456789";
            var random = new Random();
            string randomString = "";
            for (int i = 0; i < minLength/2; i++)
            {
                int stringCharactersIndex = random.Next(stringCharacters.Length);
                int stringNumbersIndex = random.Next(stringNumbers.Length);
                randomString = randomString + stringCharacters[stringCharactersIndex] + stringNumbers[stringNumbersIndex];
            }
            if (withUppercase)
            {                
                foreach (char character in randomString)
                {
                    if (char.IsLetter(character))
                    {
                        var uppercaseLetter = char.ToUpper(character);                                                
                        randomString = randomString.Insert(randomString.IndexOf(character), uppercaseLetter.ToString());
                        break;
                    }
                }
                return randomString;
            } else
            {
                return randomString;
            }
                
        }

        public static IList<int> GetRandomIntegers(int amount, int min, int max, bool canRepeat = false)
        {
            var random = new Random();
            List<int> randomIntegers = new List<int>();
            int index;
            if (!canRepeat)
            {
                for (int i = 0; i < amount; i++)
                {
                    do
                    {
                        index = random.Next(min, max);
                    } while (randomIntegers.Contains(index));
                    randomIntegers.Add(index);
                }
            } else
            {
                for (int i = 0; i < amount; i++)
                {
                    index = random.Next(min, max);
                    randomIntegers.Add(index);
                }
            }
            return randomIntegers;
        }
    }
}
