using System;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [Serializable]
    public class BoolReference : AbstractReference<bool>
    {
        public BoolReference(bool value) : base(value)
        {
        }
    }
}
