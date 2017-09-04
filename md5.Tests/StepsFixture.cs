using System;
using md5csharp;
using md5csharp.Math;
using md5csharp.Model;
using md5csharp.Transform;
using NUnit.Framework;

namespace md5.Tests
{
    public class StepsFixture
    {
        [TestCase("1")]
        [TestCase("257")]
        [TestCase("4294967295")]
        [TestCase("4294967296")]
        [TestCase("429496729777888888886", ExpectedException=typeof(ArgumentException))]
        [TestCase("foo", ExpectedException = typeof(ArgumentException))]
        public void Step12(string str)
        {
            var bits = ParseString(str);
            var step12 = new TransformChain(
                new ITransform[]
                {
                    new PaddingTransform(),
                    new LenghAppendingTransformDecorator(new WordsReverseTransform(), (ulong)bits.Size)
                }).Execute(bits);
            Assert.AreEqual(step12.Size%512, 0);
        }

        Bits ParseString(string str)
        {
            byte b = 0;
            uint ui = 0;
            ulong ul = 0;
            if (byte.TryParse(str, out b))
            {
                return new Bits(BitOperations.ByteToBits(b));
            }
            if (uint.TryParse(str, out ui))
            {
                return new Bits(BitOperations.UInt32ToBits(ui));
            }
            if (ulong.TryParse(str, out ul))
            {
                return new Bits(BitOperations.UInt64ToBits(ul));
            }
            throw new ArgumentException("cant parse string to bits: " + str);
        }
    }
}