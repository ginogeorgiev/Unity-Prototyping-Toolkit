using PrototypingToolkit.Core;
using PrototypingToolkit.Core.Extensions;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
    public class DemoPlayState : BaseState
    {
        private readonly SampleGameControllerCubeBehaviour testCube;
        private readonly GameObject hud;
        
        public DemoPlayState(StateData data, SampleGameControllerCubeBehaviour testCube, GameObject hud) : base(data)
        {
            this.testCube = testCube;
            this.hud = hud;
        }

        protected override void OnEnter()
        {
            testCube.ClickAmount.Restore();
            
            testCube.gameObject.SetActive(true);
            hud.SetActive(true);
            
            testCube.CubeRigidbody.isKinematic = true;
            UnityExtensions.ResetTransformation(testCube.transform);
            testCube.CubeRigidbody.isKinematic = false;
        }
        
        public override void Execute()
        {
                 
        }

        protected override void OnExit()
        {
            testCube.gameObject.SetActive(false);
            hud.SetActive(false);
        }
        
        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(DemoEndState);
        }
    }
}
