using System;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [Serializable]
    public class FloatReference : AbstractReference<float>
    {
        public FloatReference(float value) : base(value)
        {
        }
    }
}
