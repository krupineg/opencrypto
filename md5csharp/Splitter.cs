namespace md5csharp
{
    public class Splitter
    {
        public Bits[] Split(Bits input, uint size)
        {
            var count = (uint)input.Size/size;
            var result = new Bits[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = new Bits(input.Read(i*size, size));
            }
            return result;
        }
    }
}