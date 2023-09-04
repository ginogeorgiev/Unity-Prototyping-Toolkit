using UnityEngine;

namespace PrototypingToolkit.Core.UnityTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_VEC2V,
        fileName = PTK_MenuNames.FN_VEC2V,
        order = PTK_MenuNames.O_UVARIABLES)]
    public class Vector2Variable : AbstractVariable<Vector2>
    {
        public void AddToCurrent(Vector2 value)
        {
            currentValue += value;
            RaiseOnCurrentChangedEvent();
        }

        public void AddToCurrent(Vector2Variable value)
        {
            currentValue += value.currentValue;
            RaiseOnCurrentChangedEvent();
        }
    }
}
