using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement
{
    public class EndState : BaseState
    {
        private readonly GameData gameData;
        
        private readonly GameObject endScreen;
        
        public EndState(GameData gameData, GameObject endScreen)
        {
            this.gameData = gameData;
            this.endScreen = endScreen;
        }
        
        public override void OnEnter()
        {
            endScreen.SetActive(true);
        }
        
        public override void Execute()
        {
                 
        }
        
        public override void OnExit()
        {
            endScreen.SetActive(false);
        }
        
        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(StartState);
        }
    }
}
