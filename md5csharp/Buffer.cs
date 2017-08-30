using System.Linq;

namespace md5csharp
{
    //word A: 01 23 45 67
    //word B: 89 ab cd ef
    //word C: fe dc ba 98
    //word D: 76 54 32 10
    public class Buffer
    {
        public Buffer()
        {
            A = BitOperations.ByteToBits(0x67)
                .Concat(BitOperations.ByteToBits(0x45))
                .Concat(BitOperations.ByteToBits(0x23))
                .Concat(BitOperations.ByteToBits(0x01))
                .ToArray();
            
            B = BitOperations.ByteToBits(0xEF)
                .Concat(BitOperations.ByteToBits(0xCD))
                .Concat(BitOperations.ByteToBits(0xAB))
                .Concat(BitOperations.ByteToBits(0x89))
                .ToArray();

            C = BitOperations.ByteToBits(0x98)
                .Concat(BitOperations.ByteToBits(0xBA))
                .Concat(BitOperations.ByteToBits(0xDC))
                .Concat(BitOperations.ByteToBits(0xFE))
                .ToArray();

            D = BitOperations.ByteToBits(0x10)
                .Concat(BitOperations.ByteToBits(0x32))
                .Concat(BitOperations.ByteToBits(0x54))
                .Concat(BitOperations.ByteToBits(0x76))
                .ToArray();
        }

        public bool[] A { get; private set; }
        public bool[] B { get; private set; }
        public bool[] C { get; private set; }
        public bool[] D { get; private set; }
    }
}