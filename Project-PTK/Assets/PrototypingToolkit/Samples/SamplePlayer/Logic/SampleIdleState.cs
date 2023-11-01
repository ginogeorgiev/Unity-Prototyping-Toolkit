using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;

namespace PrototypingToolkit.Samples.SamplePlayer.Logic
{
    public class SampleIdleState : BaseState
    {
        private readonly FloatVariable movementSpeed;
        private readonly Rigidbody playerRigidbody;

        public SampleIdleState(FloatVariable movementSpeed, Rigidbody playerRigidbody)
        {
            this.movementSpeed = movementSpeed;
            this.playerRigidbody = playerRigidbody;
        }

        public override void OnEnter()
        {
            movementSpeed.Set(0f);
            playerRigidbody.velocity = Vector2.zero;
        }

        public override void OnExit()
        {
            
        }

        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(SampleWalkingState);
        }
    }
}
