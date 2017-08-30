using md5csharp;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class BufferFixture
    {
        [Test]
        public void ShouldBeCorrect()
        {
            Assert.AreEqual(new Bits(new Buffer().A).ToString(), new Bits(0x67452301).ToString());
            Assert.AreEqual(new Bits(new Buffer().B).ToString(), new Bits(0xEFCDAB89).ToString());
            Assert.AreEqual(new Bits(new Buffer().C).ToString(), new Bits(0x98BADCFE).ToString());
            Assert.AreEqual(new Bits(new Buffer().D).ToString(), new Bits(0x10325476).ToString());
        }
    }
}