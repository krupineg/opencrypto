using md5csharp;
using md5csharp.Model;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class BufferFixture
    {
        [Test]
        public void BufferShouldBeCorrectFilledByStartValues()
        {
            Assert.AreEqual(new Buffer().A, new Bits(0x67452301));
            Assert.AreEqual(new Buffer().B, new Bits(0xEFCDAB89));
            Assert.AreEqual(new Buffer().C, new Bits(0x98BADCFE));
            Assert.AreEqual(new Buffer().D, new Bits(0x10325476));
        }
    }
}