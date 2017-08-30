using System.Collections;
using System.Linq;
using md5csharp;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class PaddingTransformFixture
    {
        [Test]
        public void AtLeast1BitShouldBeApplied()
        {
            var transform = new PaddingTransform();
            var result = transform.Execute(new Bits(Enumerable.Repeat(false, PaddingTransform.Congruency - 1).ToArray()));
            Assert.AreEqual(result.Size, PaddingTransform.Congruency);
        }

        [Test]
        public void AtMost512BitShouldBeApplied()
        {
            var transform = new PaddingTransform();
            var bits = new Bits(Enumerable.Repeat(false, PaddingTransform.Congruency).ToArray());
            var result = transform.Execute(bits);
            Assert.AreEqual(result.Size - PaddingTransform.Congruency, PaddingTransform.Modulo);
        }
    }
}