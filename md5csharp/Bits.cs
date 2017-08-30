using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace md5csharp
{
    public class Bits : IEquatable<Bits>
    {
        public static readonly Bits One = new Bits(new bool[1] { true });
        public static readonly Bits Zero = new Bits(new bool[1] { false });

        public static Bits Empty(long size)
        {
            var bits = new bool[size];
            return new Bits(bits);
        }

        private readonly bool[] _bits;

        public Bits(string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);
            _bits = BitOperations.BytesArrayToBits(bytes);
        }

        public Bits(Bits bits)
        {
            _bits = bits._bits;
        }

        public Bits(uint intValue)
        {
            _bits = BitOperations.UInt32ToBits(intValue);
        }

        public Bits(bool[] bits)
        {
            _bits = bits;
        }

        public long Size { get { return checked(_bits.LongLength); } }

        public Bits Insert(long index, Bits bits)
        {
            var concat = BitOperations.Insert(_bits, index, bits._bits);
            Debug.Assert(_bits.Length + bits._bits.Length == concat.Length);
            return new Bits(concat);
        }

        public bool Equals(Bits other)
        {
            return _bits.SequenceEqual(other._bits);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var bit in _bits)
            {
                sb.Append(bit ? 1 : 0);
            }
            return sb.ToString();
        }

        public bool[] Read(int start, int end)
        {
            var size = end - start;
            var word = new bool[size];
            Array.Copy(_bits, start, word, 0, size);
            return word;
        }
    }
}