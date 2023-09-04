using UnityEngine;

namespace PrototypingToolkit.Core
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_SE,
        fileName = PTK_MenuNames.FN_SE,
        order = PTK_MenuNames.O_STATELOGIC)]
    public class StateEvent : DataEvent<BaseState>
    {
        
    }
}
