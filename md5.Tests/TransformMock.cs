using md5csharp;
using md5csharp.Model;
using md5csharp.Transform;

namespace md5.Tests
{
    public class TransformMock : ITransform
    {
        public Bits Execute(Bits input)
        {
            return input;
        }
    }
}