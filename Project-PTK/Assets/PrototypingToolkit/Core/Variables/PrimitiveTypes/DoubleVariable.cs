using UnityEngine;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_DOUBLEV,
        fileName = PTK_MenuNames.FN_DOUBLEV,
        order = PTK_MenuNames.O_VARIABLES)]
    public class DoubleVariable : AbstractVariable<double>
    {
        public void Add(double value)
        {
            currentValue += value;
            RaiseOnCurrentChangedEvent();
        }

        public void Add(DoubleVariable value)
        {
            currentValue += value.currentValue;
            RaiseOnCurrentChangedEvent();
        }
    }
}
