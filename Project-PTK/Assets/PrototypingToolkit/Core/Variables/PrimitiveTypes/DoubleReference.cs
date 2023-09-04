using System;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [Serializable]
    public class DoubleReference : AbstractReference<double>
    {
        public DoubleReference(double value) : base(value)
        {
        }
    }
}
