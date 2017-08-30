namespace md5csharp
{
    public class LenghAppendingTransform : ITransform
    {
        private readonly ITransform _transform;
        private readonly ulong _size;

        public LenghAppendingTransform(ITransform transform, ulong size)
        {
            _transform = transform;
            _size = size;
        }

        public Bits Execute(Bits input)
        {
            var sizeAsBits = _transform.Execute(new Bits(BitOperations.UInt64ToBits(_size)));
            var output = input.Insert((int)input.Size, sizeAsBits);
            return output;
        }
    }
}