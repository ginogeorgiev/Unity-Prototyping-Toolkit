using Cinemachine;
using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Samples.SamplePlayer.Logic
{
    public class SampleWalkingState : BaseState
    {
        private readonly FloatVariable curMovementSpeed;
        private readonly FloatVariable maxMovementSpeed;
        private readonly FloatVariable rotationSpeed;
        private readonly InputAction movementInputAction;
        private readonly Transform playerTransform;
        private readonly Transform playerModelTransform;
        private readonly Rigidbody playerRigidbody;
        private readonly SamplePlayerCameraType playerCameraType;
        private readonly CinemachineFreeLook thirdPersonCamera;
        private readonly CinemachineFreeLook firstPersonCamera;

        private Vector2 movementInput;

        public SampleWalkingState(
            FloatVariable curMovementSpeed, FloatVariable maxMovementSpeed, FloatVariable rotationSpeed,
            InputAction movementInputAction,
            Transform playerTransform, Transform playerModelTransform,
            Rigidbody playerRigidbody,
            SamplePlayerCameraType playerCameraType,
            CinemachineFreeLook thirdPersonCamera, CinemachineFreeLook firstPersonCamera)
        {
            this.curMovementSpeed = curMovementSpeed;
            this.maxMovementSpeed = maxMovementSpeed;
            this.rotationSpeed = rotationSpeed;
            this.movementInputAction = movementInputAction;
            this.playerTransform = playerTransform;
            this.playerModelTransform = playerModelTransform;
            this.playerRigidbody = playerRigidbody;
            this.playerCameraType = playerCameraType;
            this.thirdPersonCamera = thirdPersonCamera;
            this.firstPersonCamera = firstPersonCamera;
        }

        protected override void OnEnter()
        {
            curMovementSpeed.Set(maxMovementSpeed.Get());
        }

        internal override void Execute()
        {
            movementInput = movementInputAction.ReadValue<Vector2>();

            switch (playerCameraType)
            {
                case SamplePlayerCameraType.ISOMETRIC:
                    HandleIsometricInput();
                    break;
                case SamplePlayerCameraType.TOPDOWN:
                    HandleTopDownInput();
                    break;
                case SamplePlayerCameraType.THIRD_PERSON:
                    HandleThirdPersonInput();
                    break;
                case SamplePlayerCameraType.FIRST_PERSON:
                    HandleFirstPersonInput();
                    break;
                case SamplePlayerCameraType.SIDE_SCROLLER:
                    HandleSideScrollerInput();
                    break;
            }
        }

        private void HandleIsometricInput()
        {
            Vector3 xMovement = (playerTransform.right * (movementInput.x * curMovementSpeed.Get()));
            Vector3 zMovement = (playerTransform.forward * (movementInput.y * curMovementSpeed.Get()));
            playerRigidbody.velocity = xMovement + zMovement;
            
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            playerModelTransform.rotation = rotation;
        }

        private void HandleTopDownInput()
        {
            Vector3 xMovement = (playerTransform.right * (movementInput.x * curMovementSpeed.Get()));
            Vector3 zMovement = (playerTransform.forward * (movementInput.y * curMovementSpeed.Get()));
            playerRigidbody.velocity = xMovement + zMovement;
            
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            playerModelTransform.rotation = rotation;
        }

        private void HandleThirdPersonInput()
        {
            float cameraLookDirection = thirdPersonCamera.m_XAxis.Value;
            
            Vector3 movementDirection = Quaternion.Euler(0f, cameraLookDirection, 0f) 
                                        * new Vector3(movementInput.x, 0f, movementInput.y);

            // Apply movement to the player
            Vector3 movement = movementDirection * curMovementSpeed.Get();
            playerRigidbody.velocity = movement;

            // Rotate the player model to face the movement direction
            if (movementDirection.magnitude > 0f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                playerModelTransform.rotation = Quaternion.RotateTowards(
                    playerModelTransform.rotation, 
                    targetRotation, 
                    rotationSpeed.Get() * Time.deltaTime);
            }
        }

        private void HandleFirstPersonInput()
        {
            float cameraLookDirection = firstPersonCamera.m_XAxis.Value;
            
            Vector3 movementDirection = Quaternion.Euler(0f, cameraLookDirection, 0f) 
                                        * new Vector3(movementInput.x, 0f, movementInput.y);

            // Apply movement to the player
            Vector3 movement = movementDirection * curMovementSpeed.Get();
            playerRigidbody.velocity = movement; 
        }

        private void HandleSideScrollerInput()
        {
            Vector3 xMovement = (playerTransform.right * (movementInput.x * curMovementSpeed.Get()));
            playerRigidbody.velocity = xMovement;
            
            float targetAngle = Mathf.Atan2(movementInput.x, 0) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            playerModelTransform.rotation = rotation;
        }

        protected override void OnExit()
        {
        }

        public override bool HasNextState(BaseState nextState)
        {
            return nextState.GetType() == typeof(SampleIdleState);
        }
    }
}
