using md5csharp;
using md5csharp.Model;
using md5csharp.Transform;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class LengthAppengingTransformFixture
    {
        [TestCase(1)]
        [TestCase(100)]
        // TODO: add possibility to use big arrays 
        [TestCase(17179869183, Ignore=true)]
        public void LengthShouldBeAppended(long size)
        {
            
            var bits = Bits.Empty(size);
            var transform = new LenghAppendingTransformDecorator(new TransformMock(), (ulong)bits.Size);
            var result = transform.Execute(bits);
            Assert.AreEqual(result.Size, bits.Size + 64);
        }

        [TestCase(1)]
        [TestCase(100)]
        // TODO: add possibility to use big arrays 
        public void SizeIsAppendedFor64Bits(long size)
        {
            var bits = Bits.Empty(size);
            var transform = new LenghAppendingTransformDecorator(new TransformMock(), (ulong)bits.Size);
            var result = transform.Execute(bits);
            Assert.AreEqual(result.Size, bits.Size + 64);
        }

    }
}