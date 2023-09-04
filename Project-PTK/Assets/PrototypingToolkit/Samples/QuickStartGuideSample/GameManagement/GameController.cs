using MyBox;
using PrototypingToolkit.Core;
using PrototypingToolkit.Samples.QuickStartGuideSample.Enemies;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement
{
	[DefaultExecutionOrder(-10)]
	public class GameController : StateMachine
	{
		[Header("Data")]
		[SerializeField] private GameData gameData;
		
		[Header("Scene Refs")]
		[SerializeField] private GameObject player;
		[SerializeField] private EnemyContainerController enemyContainerController;
		
		[SerializeField] private GameObject hud;
		[SerializeField] private GameObject startScreen;
		[SerializeField] private GameObject audioDataManager;
		[SerializeField] private GameObject endScreen;

		private StartState startState;
		private GameState gameState;
		private EndState endState;
		
		private void Awake()
		{
			player.SetActive(false);
			enemyContainerController.gameObject.SetActive(false);
			hud.SetActive(false);
			endScreen.SetActive(false);
			
			gameData.ReStart.Register(EnterStartState);
			gameData.GameStart.Register(EnterGameState);
			gameData.GameOver.Register(EnterEndState);

			startState = new StartState(gameData, audioDataManager, startScreen);
			gameState = new GameState(gameData, player, enemyContainerController, hud, startScreen);
			endState = new EndState(gameData, endScreen);
			
			Initialize(startState);
		}
		
		[ButtonMethod]
		private void EnterStartState()
		{
			if (currentStateData.Get() is not StartState) TransitionTo(startState);
		}

		[ButtonMethod]
		private void EnterGameState()
		{
			if (currentStateData.Get() is not GameState) TransitionTo(gameState);
		}

		[ButtonMethod]
		private void EnterEndState()
		{
			if (currentStateData.Get() is not EndState) TransitionTo(endState);
		}
	}
}
