using UnityEngine;

namespace PrototypingToolkit.Core
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_CS,
        fileName = PTK_MenuNames.FN_CS,
        order = PTK_MenuNames.O_STATELOGIC)]
    public class CurrentStateData : ScriptableObject
    {
        private BaseState currentState;

        [Header("For Debug ONLY")]
        [SerializeField] private string currentStateName;

        public BaseState Get()
        {
            return currentState;
        }
        
        public void SetState(BaseState state)
        {
            currentState = state;
            currentState.Enter();
            SetStateInfo();
        }
        
        public void SetStateInfo()
        {
            currentStateName = currentState.GetType().Name;
        }
    }
}
