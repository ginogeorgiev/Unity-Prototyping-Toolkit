using UnityEngine;

namespace PrototypingToolkit.Core.UnityTypes
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_GOV,
        fileName = PTK_MenuNames.FN_GOV,
        order = PTK_MenuNames.O_UVARIABLES)]
    public class GameObjectVariable : AbstractVariable<GameObject>
    {
    }
}
