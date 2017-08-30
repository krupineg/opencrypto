namespace md5csharp
{
    public interface ITransform
    {
        Bits Execute(Bits input);
    }
}