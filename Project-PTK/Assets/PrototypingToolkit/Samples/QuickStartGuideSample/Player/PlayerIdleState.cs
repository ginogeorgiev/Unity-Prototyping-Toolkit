using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Player
{
    public class PlayerIdleState : BaseState
    {
        private readonly FloatVariable movementSpeed;
        private readonly Rigidbody playerRigidbody;

        public PlayerIdleState(FloatVariable movementSpeed, Rigidbody playerRigidbody)
        {
            this.movementSpeed = movementSpeed;
            this.playerRigidbody = playerRigidbody;
        }

        protected override void OnEnter()
        {
            movementSpeed.Set(0f);
            playerRigidbody.velocity = Vector2.zero;
        }

        protected override void OnExit()
        {
            
        }

        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(PlayerWalkingState);
        }
    }
}
