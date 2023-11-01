using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement
{
    public class StartState : BaseState
    {
        private readonly GameData gameData;
        
        private readonly GameObject audioDataManager;
        private readonly GameObject startScreen;
        
        public StartState(GameData gameData, GameObject audioDataManager, GameObject startScreen)
        {
            this.gameData = gameData;
            this.audioDataManager = audioDataManager;
            this.startScreen = startScreen;
        }
        
        public override void OnEnter()
        {
            audioDataManager.SetActive(true);
            startScreen.SetActive(true);
        }
        
        public override void Execute()
        {
                 
        }
        
        public override void OnExit()
        {
            audioDataManager.SetActive(false);
        }
        
        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(GameState);
        }
    }
}
