using System;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [Serializable]
    public class IntReference : AbstractReference<int>
    {
        public IntReference(int value) : base(value)
        {
        }
    }
}
