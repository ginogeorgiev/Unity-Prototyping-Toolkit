using UnityEngine;

namespace PrototypingToolkit.Core.PrimitiveTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_BOOLV,
        fileName = PTK_MenuNames.FN_BOOLV,
        order = PTK_MenuNames.O_VARIABLES)]
    public class BoolVariable : AbstractVariable<bool>
    {
        public void SetTrue()
        {
            Set(true);
        }

        public void SetFalse()
        {
            Set(false);
        }
        
        public void Toggle()
        {
            Set(!currentValue);
        }

        public bool Not()
        {
            return !Get();
        }
    }
}
