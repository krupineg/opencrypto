using System;
using System.Linq;
using md5csharp;
using md5csharp.Model;
using md5csharp.Transform;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class WordsReverseTransformFixture
    {
        [Test]
        public void TwoWordsShouldBeReversed()
        {
            var word1 = Enumerable.Repeat(true, 32);
            var word2 = Enumerable.Repeat(false, 32);
            var concat = word1.Concat(word2).ToArray();
            var bits = new Bits(concat);
            var reverse = new WordsReverseTransform().Execute(bits);
            Assert.AreEqual(reverse.Read(0, 32), word2);
            Assert.AreEqual(reverse.Read(32, 32), word1);
        }

        [TestCase(ExpectedException = typeof(ArgumentException))]
        public void IncompatibleSizeShouldOccurException()
        {
            var data = Enumerable.Repeat(true, 33).ToArray();
            var bits = new Bits(data);
            new WordsReverseTransform().Execute(bits);
        }
    }
}