using System;

namespace md5csharp
{
    public class WordsReverseTransform : ITransform
    {
        public Bits Execute(Bits input)
        {
            if (input.Size % 32 != 0)
            {
                throw new ArgumentException("Input length should be multiple of 32 [size of word]");
            }

            var wordsCount = input.Size/32;
            var words = new bool[wordsCount][];

            for (int i = 0; i < wordsCount; i++)
            {
                var start = i*32;
                words[i] = input.Read(start, 32);
            }

            Array.Reverse(words);

            var output = new bool[input.Size];
            for (int i = 0; i < wordsCount; i++)
            {
                var start = i*32;
                Array.Copy(words[i], 0, output, start, 32);
            }

            return new Bits(output);
        }
    }
}