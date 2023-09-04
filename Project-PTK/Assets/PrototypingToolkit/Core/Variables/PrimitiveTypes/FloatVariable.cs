using UnityEngine;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_FLOATV,
        fileName = PTK_MenuNames.FN_FLOATV,
        order = PTK_MenuNames.O_VARIABLES)]
    public class FloatVariable : AbstractVariable<float>
    {
        public void AddToCurrent(float value)
        {
            currentValue += value;
            RaiseOnCurrentChangedEvent();
        }

        public void AddToCurrent(FloatVariable value)
        {
            currentValue += value.currentValue;
            RaiseOnCurrentChangedEvent();
        }
    }
}
