using PrototypingToolkit.Core;
using PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement;
using UnityEngine;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.Player
{
    public class PlayerController : StateMachine
    {
        [Header("Data")]
        [SerializeField] private GameData gameData;

        [Header("Debug")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform model;
        [SerializeField] private Vector2 movementInput;

        private PlayerIdleState playerIdleState;
        private PlayerWalkingState playerWalkingState;
        
        private void Awake()
        {
            if (!rb) rb = GetComponent<Rigidbody>();
            if (!model) model = transform.GetChild(0);

            playerIdleState = new PlayerIdleState(gameData.PlayerCurrentMovementSpeed, rb);
            
            SetWalkingState();
            
            Initialize(playerIdleState);
            
            gameData.PlayerTransform = transform;
        }

        private void SetWalkingState()
        {
            playerWalkingState = new PlayerWalkingState(
                gameData.PlayerCurrentMovementSpeed, gameData.PlayerMaxMovementSpeed,
                gameData.PlayerMovementInput.action,
                transform, model,
                rb);
        }

        private void OnEnable()
        {
            gameData.PlayerMovementInput.action.Enable();
        }

        private void OnDisable()
        {
            gameData.PlayerMovementInput.action.Disable();
        }

        private void Update()
        {
            gameData.PlayerTransform = transform;
            HandleKeyboardInput();
        }

        private void FixedUpdate()
        {
            Execute();
        }

        private void HandleKeyboardInput()
        {
            movementInput = gameData.PlayerMovementInput.action.ReadValue<Vector2>();

            if (movementInput.x != 0 || movementInput.y != 0)
            {
                if (currentStateData.Get() is not PlayerWalkingState) TransitionTo(playerWalkingState);
            }
            else
            {
                if (currentStateData.Get() is not PlayerIdleState) TransitionTo(playerIdleState);
            }
        }
    }
}
