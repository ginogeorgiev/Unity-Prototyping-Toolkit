using MyBox;
using PrototypingToolkit.Core;
using PrototypingToolkit.Samples.QuickStartGuideSample.Enemies;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement
{
    public class GameState : BaseState
    {
        private readonly GameData gameData;
        
        private readonly GameObject player;
        private readonly EnemyContainerController enemyContainerController;
        
        private readonly GameObject hud;
        private readonly GameObject startScreen;
        
        public GameState(GameData gameData,
            GameObject player, EnemyContainerController enemyContainerController,
            GameObject hud, GameObject startScreen)
        {
            this.gameData = gameData;
            this.player = player;
            this.enemyContainerController = enemyContainerController;

            this.hud = hud;
            this.startScreen = startScreen;
        }

        protected override void OnEnter()
        {
            player.transform.ResetPosition();
            
            hud.SetActive(true);
            
            gameData.PlayerHealth.Restore();
            gameData.CurCoolDown.Restore();
            
            gameData.PlayerHealth.OnCurrentChanged.Register(OnPlayerHealthChanged);
            
            enemyContainerController.gameObject.SetActive(true);
            player.SetActive(true);
            
            startScreen.SetActive(false);
        }
        
        private void OnPlayerHealthChanged()
        {
            if (gameData.PlayerHealth.Get() <= 0)
            {
                gameData.GameOver.Raise();
                gameData.AudioData.PlayAudioEvent.Raise(gameData.GameOverSound);
            }
        }

        public override void Execute()
        {
            
        }

        protected override void OnExit()
        {
            gameData.DealDamageToPlayer.Unregister(OnPlayerHealthChanged);
            
            enemyContainerController.gameObject.SetActive(false);
            enemyContainerController.Clear();
            player.SetActive(false);
            
            hud.SetActive(false);
        }
        
        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(EndState);
        }
    }
}
