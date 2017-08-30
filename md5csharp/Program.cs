using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace md5csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringValue = "1dfskdfmsdlkfsdngsjkngfsjkgnlkjfndlfkgdfblkgbdlkdfjgbdflkjgbdfjkg1dfskdfmsdlkfsdngsjkngfsjkgnlkjfndlfkgbdflkgbdlkdfjgbdflkjgbdfjkg4";
            var bits = new Bits(stringValue, Encoding.UTF8);
            var step12 = new TransformChain(
                new ITransform[]
                {
                    new PaddingTransform(),
                    new LenghAppendingTransform(new WordsReverseTransform(), (ulong)bits.Size)
                });
            var chain = new TransformChain(new ITransform[]
            {
                step12
            });
            bits = chain.Execute(bits);
        }
    }
}
