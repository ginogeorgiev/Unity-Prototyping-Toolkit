using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Player
{
    public class PlayerWalkingState : BaseState
    {
        private readonly FloatVariable curMovementSpeed;
        private readonly FloatVariable maxMovementSpeed;
        private readonly InputAction movementInputAction;
        private readonly Transform playerTransform;
        private readonly Transform playerModelTransform;
        private readonly Rigidbody playerRigidbody;

        private Vector2 movementInput;

        public PlayerWalkingState(
            FloatVariable curMovementSpeed, FloatVariable maxMovementSpeed,
            InputAction movementInputAction,
            Transform playerTransform, Transform playerModelTransform,
            Rigidbody playerRigidbody)
        {
            this.curMovementSpeed = curMovementSpeed;
            this.maxMovementSpeed = maxMovementSpeed;
            this.movementInputAction = movementInputAction;
            this.playerTransform = playerTransform;
            this.playerModelTransform = playerModelTransform;
            this.playerRigidbody = playerRigidbody;
        }

        protected override void OnEnter()
        {
            curMovementSpeed.Set(maxMovementSpeed.Get());
        }

        internal override void Execute()
        {
            movementInput = movementInputAction.ReadValue<Vector2>();

            HandleIsometricInput();
        }

        private void HandleIsometricInput()
        {
            if (movementInput.x == 0 && movementInput.y == 0) return;
            
            Vector3 xMovement = (playerTransform.right * (movementInput.x * curMovementSpeed.Get()));
            Vector3 zMovement = (playerTransform.forward * (movementInput.y * curMovementSpeed.Get()));
            playerRigidbody.velocity = xMovement + zMovement;
            
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            playerModelTransform.rotation = rotation;
        }

        protected override void OnExit()
        {
        }

        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(PlayerIdleState);
        }
    }
}
