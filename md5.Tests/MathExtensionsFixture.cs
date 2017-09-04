using md5csharp;
using md5csharp.Math;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class MathExtensionsFixture
    {
        [TestCase(15, 4, 11, 0)]
        [TestCase(16, 37, 3, 0)]
        [TestCase(5, 9, 3, 1)]
        [TestCase(5, 15, 5, 0)]
        [TestCase(448, 448, 512, 0)]
        [TestCase(960, 448, 512, 0)]
        [TestCase(1472, 448, 512, 0)]
        [TestCase(1473, 448, 512, 511)]
        [TestCase(1471, 448, 512, 1)]
        public void Congruent(int left, int right, int modulo, int diff)
        {
            Assert.AreEqual(diff, MathExtensions.Congruent(left, right, modulo));
        }

        [TestCase(new bool[] { true, false, true }, 1u, new bool[] { false, true, true })]
        [TestCase(new bool[] { true, false, true, true, true }, 2u, new bool[] { true, true, true, true, false })]
        [TestCase(new bool[] { true, false, true }, 3u, new bool[] { true, false, true })]
        [TestCase(new bool[] { true, false, true }, 4u, new bool[] { false, true, true })]
        public void RoundShiftLeft(bool[] value, uint shift, bool[] result)
        {
            Assert.AreEqual(MathExtensions.RoundShiftLeft(value, shift), result);
        }
    }
}