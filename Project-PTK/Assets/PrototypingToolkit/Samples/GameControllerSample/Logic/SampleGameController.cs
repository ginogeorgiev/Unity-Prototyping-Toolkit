using MyBox;
using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
	[DefaultExecutionOrder(-10)]
	public class SampleGameController : StateMachine
	{
		[Header("State Data")]
		[SerializeField] private StateData samplePlayStateData;
		[SerializeField] private EmptyEvent sampleDoneButton;
		[SerializeField] private EmptyEvent sampleRestartButton;
		
		[Header("Scene Refs")]
		[SerializeField] private SampleGameControllerCubeBehaviour sampleCube;
		
		[SerializeField] private GameObject hud;
		[SerializeField] private GameObject result;

		private DemoPlayState samplePlayState;
		private DemoEndState sampleEndState;

		private void Awake()
		{
			sampleCube.gameObject.SetActive(false);
			hud.SetActive(false);
			result.SetActive(false);
			
			sampleDoneButton.Register(EnterDemoEndState);
			sampleRestartButton.Register(EnterDemoPlayState);

			samplePlayState = new DemoPlayState(samplePlayStateData, sampleCube, hud);
			sampleEndState = new DemoEndState(result);
			
			Initialize(samplePlayState);
		}

		[ButtonMethod]
		private void EnterDemoPlayState()
		{
			if (currentStateData.Get() is not DemoPlayState) TransitionTo(samplePlayState);
		}

		[ButtonMethod]
		private void EnterDemoEndState()
		{
			if (currentStateData.Get() is not DemoEndState) TransitionTo(sampleEndState);
		}
	}
}
