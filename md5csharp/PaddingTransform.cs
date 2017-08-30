using System.Linq;

namespace md5csharp
{
    public class PaddingTransform : ITransform
    {
        public const int Modulo = 512;
        public const int Congruency = 448;

        public Bits Execute(Bits input)
        {
            var bits = input.Insert(0, Bits.One);
            var size = bits.Size;
            var appendixSize = MathExtensions.Congruent(size, Congruency, Modulo);
            if (appendixSize > 0)
            {
                bits = bits.Insert(bits.Size, new Bits(Enumerable.Repeat(false, (int)appendixSize).ToArray()));
            }
            return bits;
        }
    }
}