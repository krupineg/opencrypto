using System.Linq;
using md5csharp;
using md5csharp.Model;
using md5csharp.Transform;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class SplitterFixture
    {
        [Test]
        public void SplitsToCorrectSizeChunks()
        {
            var splitter = new SplitterTransform();
            foreach (var chunk in splitter.Split(Bits.Empty(256), 64))
            {
                Assert.AreEqual(chunk.Size, 64);
            }
        }

        [Test]
        public void SplitsToCorrectChunksCount()
        {
            var splitter = new SplitterTransform();
            Assert.AreEqual(splitter.Split(Bits.Empty(512), 64).Length, 8);
        }

        [Test]
        public void ChunksHaveCorrectContent()
        {
            var word1 = Enumerable.Repeat(true, 64);
            var word2 = Enumerable.Repeat(false, 64);
            var concat = word1.Concat(word2).ToArray();
            var bits = new Bits(concat);
            var splitter = new SplitterTransform();
            var chunks = splitter.Split(bits, 64);
            Assert.AreEqual(chunks[0], new Bits(word1));
            Assert.AreEqual(chunks[1], new Bits(word2));
        }
    }
}