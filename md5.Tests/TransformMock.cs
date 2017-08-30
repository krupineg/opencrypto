using md5csharp;

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