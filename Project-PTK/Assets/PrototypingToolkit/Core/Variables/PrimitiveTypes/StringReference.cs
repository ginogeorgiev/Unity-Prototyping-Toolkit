using System;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [Serializable]
    public class StringReference : AbstractReference<string>
    {
        public StringReference(string value) : base(value)
        {
        }
    }
}
