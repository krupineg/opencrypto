﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using md5csharp;
using NUnit.Framework;

namespace md5.Tests
{
    [TestFixture]
    public class BitOperationsFixture
    {
        [Test]
        public void BitsInByteShouldBe8()
        {
            Assert.AreEqual(8, BitOperations.BitsInByte);
        }

        [TestCase(0, new bool[] { false, false, false, false, false, false, false, false })]
        [TestCase(1, new bool[] { false, false, false, false, false, false, false, true })]
        [TestCase(2, new bool[] { false, false, false, false, false, false, true, false })]
        [TestCase(8, new bool[] { false, false, false, false, true, false, false, false })]
        [TestCase(16, new bool[] { false, false, false, true, false, false, false, false })]
        [TestCase(32, new bool[] { false, false, true, false, false, false, false, false })]
        [TestCase(255, new bool[] { true, true, true, true, true, true, true, true })]
        [TestCase(254, new bool[] { true, true, true, true, true, true, true, false })]
        public void ConvertBytesToBitsCorrectly(byte byteval, bool[] bitsArray)
        {
            var bits = new Bits(BitOperations.ByteToBits(byteval));
            var bits2 = new Bits(bitsArray);
            Assert.AreEqual(bits, bits2);
        }

        [TestCase(0u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false })]
        [TestCase(1u, new bool[] {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true })]
        [TestCase(2u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false })]
        [TestCase(8u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false })]
        [TestCase(16u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false })]
        [TestCase(32u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false })]
        [TestCase(255u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true })]
        [TestCase(254u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, false })]
        [TestCase(256u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false })]
        [TestCase(512u, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false })]
        [TestCase(4294967295u, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true })]   
        [TestCase(2147483648u, new bool[] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false })]
        public void ConvertIntsToBitsCorrectly(uint intval, bool[] bitsArray)
        {
            var bits = new Bits(BitOperations.UInt32ToBits(intval));
            var bits2 = new Bits(bitsArray);
            Assert.AreEqual(bits, bits2);
            Assert.AreEqual(bits.Size, 32);
        }

        [TestCase('0', new bool[] {false, false, true, true, false, false, false, false})]
        [TestCase('1', new bool[] { false, false, true, true, false, false, false, true })]
        [TestCase('2', new bool[] { false, false, true, true, false, false, true, false })]
        [TestCase('9', new bool[] { false, false, true, true, true, false, false, true })]
        [TestCase('a', new bool[] { false, true, true, false, false, false, false, true })]
        [TestCase('Z', new bool[] { false, true, false, true, true, false, true, false })]
        public void SingleByteIsConvertedCorrectly(char character, bool[] result)
        {
            var byteValue = (byte) character;
            var bools = BitOperations.ByteToBits(byteValue);
            Assert.AreEqual(bools, result);
        }

        [TestCase(arguments: new object[]
        { 
            new bool[] { false, true, false, true, true, false, true, false },
            4,
            new bool[] { false },
            new bool[] { false, true, false, true, false, true, false, true, false }
        })]
        [TestCase(arguments: new object[]
        { 
            new bool[] { false, true, false, true, true, false, true, false },
            0,
            new bool[] { true },
            new bool[] { true, false, true, false, true, true, false, true, false }
        })]
        [TestCase(arguments: new object[]
        { 
            new bool[] { false, true, false, true, true, false, true, false },
            1,
            new bool[] { true },
            new bool[] { false, true, true, false, true, true, false, true, false }
        })]
        [TestCase(arguments: new object[]
        { 
            new bool[] { false, true, false, true, true, false, true, false },
            8,
            new bool[] { true },
            new bool[] { false, true, false, true, true, false, true, false, true }
        })]
        [TestCase(arguments: new object[]
        { 
            new bool[] { false, true, false, true, true, false, true, false },
            7,
            new bool[] { true },
            new bool[] { false, true, false, true, true, false, true, true, false }
        })]
        [TestCase(arguments: new object[]
        { 
            new bool[] { false, true, false, true, true, false, true, false },
            7,
            new bool[] { true, true },
            new bool[] { false, true, false, true, true, false, true, true, true, false }
        })]
        public void BitsCanBeInsertedCorrectly(bool[] input, int index, bool[] values, bool[] result)
        {
            Assert.AreEqual(result, BitOperations.Insert(input, index, values));
        }

        [TestCase(0, 300, 200)]
        [TestCase(100, 300, 200)]
        [TestCase(200, 200, 300)]
        public void LongAppendixShouldBeAttached(int index, int leftSize ,int rightSize)
        {
            var longBits = Enumerable.Repeat(false, leftSize).ToArray();
            var appendix = Enumerable.Repeat(true, rightSize).ToArray();
            var result = BitOperations.Insert(longBits, index, appendix);
            Assert.AreEqual(result.Length, rightSize + leftSize);
        }
    }
}