using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using md5csharp;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class TransformChainFixture
    {
        [Test]
        public void EachTransformShouldBeExecutedInOrderOfInput()
        {
            var indexes = Enumerable.Range(0, 10);
            var stream = new List<int>();
            var transforms = indexes.Select(x => new TransformMock((b) =>
            {
                stream.Add(x);
                return b;
            }));
            var transformChain = new TransformChain(transforms);
            transformChain.Execute(Bits.One);
            Assert.AreEqual(stream, indexes);
        }

        [Test]
        public void EachTransformShouldBeReflectedOnResultSimpultaneously()
        {
            var indexes = Enumerable.Range(0, 10);
            var transforms = indexes.Select(x => new TransformMock((b) =>
            {
                return b.Insert(b.Size, b);
            }));
            var transformChain = new TransformChain(transforms);
            var bits = Bits.One;
            var result = transformChain.Execute(bits);
            Assert.AreEqual(result.Size, (long)Math.Pow(2, 10));
        }

        private class TransformMock : ITransform
        {
            private readonly Func<Bits, Bits> _callback;

            public TransformMock(Func<Bits, Bits> callback)
            {
                _callback = callback;
            }

            public Bits Execute(Bits input)
            {
                return _callback.Invoke(input);
            }
        }
    }
}