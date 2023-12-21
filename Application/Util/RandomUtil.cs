using System;

namespace Application.Util
{
    public class RandomUtil
    {
        public static int RangeNumber(int from, int to)
        {
            return new Random().Next(from, to);
        }
    }
}
