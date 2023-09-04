#if UNITY_EDITOR
using PrototypingToolkit.Core;
#endif
using UnityEngine;

namespace PrototypingToolkit.Core.UnityTypes
{
#if UNITY_EDITOR
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_CV,
        fileName = PTK_MenuNames.FN_CV,
        order = PTK_MenuNames.O_UVARIABLES)]
#endif
    public class ColorVariable : AbstractVariable<Color>
    {
    }
}
