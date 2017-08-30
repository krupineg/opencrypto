using System;

namespace md5csharp
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

        
    }
}