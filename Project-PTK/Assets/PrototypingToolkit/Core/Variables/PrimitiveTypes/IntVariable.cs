using UnityEngine;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_INTV,
        fileName = PTK_MenuNames.FN_INTV,
        order = PTK_MenuNames.O_VARIABLES)]
    public class IntVariable : AbstractVariable<int>
    {
        public void Add(int value)
        {
            currentValue += value;
            RaiseOnCurrentChangedEvent();
        }

        public void Add(IntVariable value)
        {
            currentValue += value.currentValue;
            RaiseOnCurrentChangedEvent();
        }
    }
}
