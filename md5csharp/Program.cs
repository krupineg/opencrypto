using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using md5csharp.Model;
using md5csharp.Transform;

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
                    new LenghAppendingTransformDecorator(new WordsReverseTransform(), (ulong)bits.Size),
                });
            var step24 = new TransformChain(new ITransform[]
            {
                step12
            });
            bits = step24.Execute(bits);
        }
    }
}
