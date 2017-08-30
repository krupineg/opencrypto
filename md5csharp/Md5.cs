using System;
using System.Linq;

namespace md5csharp
{
    //F(X,Y,Z) = XY v not(X) Z
    //G(X,Y,Z) = XZ v Y not(Z)
    //H(X,Y,Z) = X xor Y xor Z
    //I(X,Y,Z) = Y xor (X v not(Z))
    public class Md5
    {
        private static readonly ulong _twoIn64 = (ulong)Math.Pow(2, 64);
        private static readonly ulong[] _t = Enumerable.Range(1, 65).Select(Sin).ToArray();

        public ulong[] T
        {
            get { return _t; }
        }
        
        public static ulong Sin(int n)
        {
            return (ulong)(_twoIn64*Math.Abs(Math.Sin(n)));
        }

        public bool F(bool x, bool y, bool z)
        {
            return x & y | !x & z;
        }

        public bool G(bool x, bool y, bool z)
        {
            return x & z | y & !z;
        }
        public bool H(bool x, bool y, bool z)
        {
            return x ^ y ^ z;
        }
        public bool I(bool x, bool y, bool z)
        {
            return y ^ (x | !z);
        }
    }
}