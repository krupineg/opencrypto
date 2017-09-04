using System;

namespace md5csharp
{
    public class MathExtensions
    {
        public static long Congruent(long left, long right, int modulo)
        {
            var rightMod = right%modulo;
            var leftMod = left % modulo;

            var diff = rightMod - leftMod;
            if (diff < 0)
            {
                diff = modulo + diff;
            }
            return diff;
        }

        public static bool[] RoundShiftLeft(bool[] input, uint count)
        {
            count = count % (uint)input.Length;
            var buffer = new bool[count];
            Array.Copy(input, 0, buffer, 0, count);
            Array.Copy(input, count, input, 0, input.Length - count);
            Array.Copy(buffer, 0, input, input.Length - count, count);
            return input;
        }
    }
}