using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;

namespace PrototypingToolkit.Core
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_SD,
        fileName = PTK_MenuNames.FN_SD,
        order = PTK_MenuNames.O_STATELOGIC)]
    public class StateData : ScriptableObject
    {
        [Header("Can be filled optionally if needed")]
        
        [Header("Bools")]
        [SerializeField] private BoolVariable isExecuting;
        
        [Header("Enter-/Exit-Events of states")]
        [SerializeField] private StateEvent onBeforeEnterEvent;
        [SerializeField] private StateEvent onAfterEnterEvent;
        [SerializeField] private StateEvent onBeforeExitEvent;
        [SerializeField] private StateEvent onAfterExitEvent;

        public BoolVariable IsExecuting => isExecuting;

        public StateEvent OnBeforeEnterEvent => onBeforeEnterEvent;
        public StateEvent OnAfterEnterEvent => onAfterEnterEvent;
        public StateEvent OnBeforeExitEvent => onBeforeExitEvent;
        public StateEvent OnAfterExitEvent => onAfterExitEvent;
    }
}
