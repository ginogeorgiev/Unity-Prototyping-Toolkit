using UnityEngine;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_STRINGV,
        fileName = PTK_MenuNames.FN_STRINGV,
        order = PTK_MenuNames.O_VARIABLES)]
    public class StringVariable : AbstractVariable<string>
    {
        public void Append(string value)
        {
            currentValue += value;
            RaiseOnCurrentChangedEvent();
        }

        public void Append(StringVariable value)
        {
            currentValue += value.currentValue;
            RaiseOnCurrentChangedEvent();
        }
    }
}
