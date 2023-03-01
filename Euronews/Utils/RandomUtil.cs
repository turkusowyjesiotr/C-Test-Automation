using System;

namespace Euronews.Utils
{
    public static class RandomUtil
    {
        public static int GetRandomInteger(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
