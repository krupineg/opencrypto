using System.Linq;
using md5csharp;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class BitsFixture
    {
        [TestCase(new[] { true, true, true, true, true, true, true, true }, new[] { true, true, true, true, true, true, true, true }, new[] { false, false, false, false, false, false, false, false })]
        [TestCase(new[] { true, false, true, false, true, false, true }, new[] { true, false, true, false, true, false, true }, new[] { false, false, false, false, false, false, false })]
        [TestCase(new[] { true, false, false, false, false, true }, new[] { true, true, true, false, false, false }, new[] { false, true, true, false, false, true })]
        [TestCase(new[] { true, true, false, true }, new[] { false, false, false, false }, new[] { true, true, false, true })]
        public void Xor(bool[] a, bool[] b, bool[] result)
        {
            Assert.AreEqual(new Bits(a) ^ new Bits(b), new Bits(result));
        }

        [TestCase(new[] { true, true, true, true, true, true, true, true }, new[] { true, true, true, true, true, true, true, true }, new[] { true, true, true, true, true, true, true, true })]
        [TestCase(new[] { true, false, true, false, true, false, true }, new[] { true, false, true, false, true, false, true }, new[] { true, false, true, false, true, false, true })]
        [TestCase(new[] { true, false, false, false, false, true }, new[] { true, true, true, false, false, false }, new[] { true, true, true, false, false, true })]
        [TestCase(new[] { false, false, false, false }, new[] { false, false, false, false }, new[] { false, false, false, false })]
        public void Or(bool[] a, bool[] b, bool[] result)
        {
            Assert.AreEqual(new Bits(a) | new Bits(b), new Bits(result));
        } 

        [TestCase(new[] { true, true, true, true, true, true, true, true }, new[] { true, true, true, true, true, true, true, true }, new[] { true, true, true, true, true, true, true, true })]
        [TestCase(new[] { true, false, true, false, true, false, true }, new[] { true, false, true, false, true, false, true }, new[] { true, false, true, false, true, false, true })]
        [TestCase(new[] { true, false, false, false, false, true }, new[] { true, true, true, false, false, false }, new[] { true, false, false, false, false, false })]
        [TestCase(new[] { false, false, false, false }, new[] { false, false, false, false }, new[] { false, false, false, false })]
        public void And(bool[] a, bool[] b, bool[] result)
        {
            Assert.AreEqual(new Bits(a) & new Bits(b), new Bits(result));
        }   
    }
}