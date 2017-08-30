using System.Collections.Generic;

namespace md5csharp
{
    public class TransformChain : ITransform
    {
        private readonly IEnumerable<ITransform> _transforms;

        public TransformChain(IEnumerable<ITransform> transforms)
        {
            _transforms = transforms;
        }

        public Bits Execute(Bits input)
        {
            var currentValues = input;
            foreach (var transform in _transforms)
            {
                currentValues = transform.Execute(currentValues);
            }
            return currentValues;
        }
    }
}