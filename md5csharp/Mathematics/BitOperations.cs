using System;
using System.Linq;

namespace md5csharp.Mathematics
{
    public class BitOperations
    {
        public const int BitsInByte = 8;

        public static bool[] BytesArrayToBits(byte[] bytes)
        {
            var result = new bool[bytes.Length * BitsInByte];
            for (int i = 0; i < bytes.Length; i++)
            {
                Array.Copy(ByteToBits(bytes[i]), 0, result, i * BitsInByte, BitsInByte);
            }
            return result;
        }

        public static bool[] ByteToBits(byte b)
        {
            return Parse(b, BitsInByte);
        }

        public static bool[] UInt32ToBits(uint intValue)
        {
            return Parse(intValue, sizeof (uint) * BitsInByte);
        }

        public static bool[] UInt64ToBits(ulong intValue)
        {
            return Parse(intValue, sizeof(ulong) * BitsInByte);
        }
        
        private static bool[] Parse(ulong value, int size)
        {
            var buffer = value;
            var result = new bool[size];
            var rightOffset = 0;
            while (buffer > 0)
            {
                var mod = buffer % 2;
                buffer = buffer >> 1;
                result[size - ++rightOffset] = mod == 1;
            }
            return result;
        }

        public static bool[] Insert(bool[] bits, long index, params bool[] values)
        {
            if (index < 0 || index > bits.Length)
            {
                throw new ArithmeticException("Unable to insert to index " + index);
            }
            var result = new bool[bits.Length + values.Length];
            Array.Copy(bits, 0, result, 0, index);
            Array.Copy(values, 0, result, index, values.Length);
            Array.Copy(bits, index, result, index + values.Length, bits.Length - index);
            return result;
        }

        public static bool[] Sum(bool[] left, bool[] right)
        {
            bool[] result = new bool[64];
            left = ResizeIn64Bit(left);
            right = ResizeIn64Bit(right);
            bool next = false;
            for (int i = 63; i >= 0; i--)
            {
                result[i] = AddBits(left[i], right[i], next, out next);
            }
            return result;
        }

        public static bool AddBits(bool left, bool right, bool previous, out bool toNext)
        {
            var trues = new[] {left, right, previous}.Where(x => x).Count();
            toNext = trues >= 2;
            return trues == 1 || trues == 3;

            //toNext = left && right || right && previous || left && previous;
            //return 
            //    left && right && previous || 
            //    left && !right && !previous ||
            //    !left && !right && previous ||
            //    !left && right && !previous;
        }

        private static bool[] ResizeIn64Bit(bool[] input)
        {
            if (input.Length == 64)
            {
                return input;
            }
            var input64 = new bool[64];
            Array.Copy(input, 0, input64, 64 - input.Length, input.Length);
            return input64;
        }

        public static bool[] Not(bool[] input)
        {
            var output = new bool[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                output[i] = !input[i];
            }
            return output;
        }

        public static bool[] Apply(Func<bool, bool, bool> functor, bool[] input1, bool[] input2)
        {
            if (input1.Length != input2.Length)
            {
                throw new ArgumentException("inputs length should be the same");
            }
            var output = new bool[input1.Length];
            for (var i = 0; i < input1.Length; i++)
            {
                output[i] = functor(input1[i], input2[i]);
            }
            return output;
        }

    }
}