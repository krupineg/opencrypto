using md5csharp.Model;

namespace md5csharp.Transform
{
    public interface ITransform
    {
        Bits Execute(Bits input);
    }
}