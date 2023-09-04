using UnityEngine;
using PrototypingToolkit.Core;

namespace PrototypingToolkit.Core.UnityTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_VEC3V,
        fileName = PTK_MenuNames.FN_VEC3V,
        order = PTK_MenuNames.O_UVARIABLES)]
    public class Vector3Variable : AbstractVariable<Vector3>
    {
        public void AddToCurrent(Vector3 value)
        {
            currentValue += value;
            RaiseOnCurrentChangedEvent();
        }

        public void AddToCurrent(Vector3Variable value)
        {
            currentValue += value.currentValue;
            RaiseOnCurrentChangedEvent();
        }
    }
}
