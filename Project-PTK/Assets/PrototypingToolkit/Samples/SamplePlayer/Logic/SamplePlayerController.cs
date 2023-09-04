using Cinemachine;
using MyBox;
using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Samples.SamplePlayer.Logic
{
    public enum SamplePlayerCameraType
    {
        ISOMETRIC = 1,
        TOPDOWN = 2,
        THIRD_PERSON = 3,
        FIRST_PERSON = 4,
        SIDE_SCROLLER = 5,
    }
    public class SamplePlayerController : StateMachine
    {
        [Foldout("Refs", true)]
        [Header("Data")]
        [SerializeField] private FloatVariable maxMovementSpeed;
        [SerializeField] private FloatVariable currentMovementSpeed;
        [SerializeField] private FloatVariable rotationSpeed;
        [SerializeField] private InputActionReference movement;
        [SerializeField] private SamplePlayerCameraType playerCameraType;
        
        [Header("Internal Refs")]
        [SerializeField] private GameObject isometric;
        [SerializeField] private GameObject topDown;
        [SerializeField] private GameObject thirdPerson;
        [SerializeField] private GameObject firstPerson;
        [SerializeField] private GameObject sideScroller;
        [SerializeField] private CinemachineFreeLook thirdPersonCamera;
        [SerializeField] private CinemachineFreeLook firstPersonCamera;
        
        [Foldout("Debug", true)]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform model;
        [SerializeField] private Vector2 movementInput;

        private SampleIdleState sampleIdleState;
        private SampleWalkingState sampleWalkingState;
        
        private void Awake()
        {
            if (!rb) rb = GetComponent<Rigidbody>();
            if (!model) model = transform.GetChild(0);

            SetCam();

            sampleIdleState = new SampleIdleState(currentMovementSpeed, rb);
            
            SetWalkingState();
            
            Initialize(sampleIdleState);
        }

        private void SetWalkingState()
        {
            sampleWalkingState = new SampleWalkingState(
                currentMovementSpeed, maxMovementSpeed, rotationSpeed,
                movement.action,
                transform, model,
                rb,
                playerCameraType,
                thirdPersonCamera, firstPersonCamera);
        }

        private void OnEnable()
        {
            movement.action.Enable();
        }

        private void OnDisable()
        {
            movement.action.Disable();
        }

        private void Update()
        {
            HandleKeyboardInput();
        }

        private void FixedUpdate()
        {
            Execute();
        }

        private void HandleKeyboardInput()
        {
            movementInput = movement.action.ReadValue<Vector2>();

            if (movementInput.x != 0 || movementInput.y != 0)
            {
                if (currentStateData.Get() is not SampleWalkingState) TransitionTo(sampleWalkingState);
            }
            else
            {
                if (currentStateData.Get() is not SampleIdleState) TransitionTo(sampleIdleState);
            }
        }

        private void SetCam()
        {
            switch (playerCameraType)
            {
                case SamplePlayerCameraType.ISOMETRIC:
                    model.gameObject.SetActive(true);
                    isometric.SetActive(true);
                    topDown.SetActive(false);
                    thirdPerson.SetActive(false);
                    firstPerson.SetActive(false);
                    sideScroller.SetActive(false);
                    break;
                case SamplePlayerCameraType.TOPDOWN:
                    model.gameObject.SetActive(true);
                    isometric.SetActive(false);
                    topDown.SetActive(true);
                    thirdPerson.SetActive(false);
                    firstPerson.SetActive(false);
                    sideScroller.SetActive(false);
                    break;
                case SamplePlayerCameraType.THIRD_PERSON:
                    model.gameObject.SetActive(true);
                    isometric.SetActive(false);
                    topDown.SetActive(false);
                    thirdPerson.SetActive(true);
                    firstPerson.SetActive(false);
                    sideScroller.SetActive(false);
                    break;
                case SamplePlayerCameraType.FIRST_PERSON:
                    model.gameObject.SetActive(false);
                    isometric.SetActive(false);
                    topDown.SetActive(false);
                    thirdPerson.SetActive(false);
                    firstPerson.SetActive(true);
                    sideScroller.SetActive(false);
                    break;
                case SamplePlayerCameraType.SIDE_SCROLLER:
                    model.gameObject.SetActive(true);
                    isometric.SetActive(false);
                    topDown.SetActive(false);
                    thirdPerson.SetActive(false);
                    firstPerson.SetActive(false);
                    sideScroller.SetActive(true);
                    break;
            }
        }

        [ButtonMethod]
        private void ChangeToIsometricView()
        {
            if (playerCameraType == SamplePlayerCameraType.ISOMETRIC) return;
            
            SetPlayerCameraType(SamplePlayerCameraType.ISOMETRIC);
            
            SetCam();
            
            SetWalkingState();
        }

        [ButtonMethod]
        private void ChangeToTopDownView()
        {
            if (playerCameraType == SamplePlayerCameraType.TOPDOWN) return;
            
            SetPlayerCameraType(SamplePlayerCameraType.TOPDOWN);
            
            SetCam();
            
            SetWalkingState();
        }
        
        [ButtonMethod]
        private void ChangeToThirdPersonView()
        {
            if (playerCameraType == SamplePlayerCameraType.THIRD_PERSON) return;
            
            SetPlayerCameraType(SamplePlayerCameraType.THIRD_PERSON);
            
            SetCam();
            
            SetWalkingState();
        }
        
        [ButtonMethod]
        private void ChangeToFirstPersonView()
        {
            if (playerCameraType == SamplePlayerCameraType.FIRST_PERSON) return;
            
            SetPlayerCameraType(SamplePlayerCameraType.FIRST_PERSON);
            
            SetCam();
            
            SetWalkingState();
        }

        [ButtonMethod]
        private void ChangeToSideScrollerView()
        {
            if (playerCameraType == SamplePlayerCameraType.SIDE_SCROLLER) return;
            
            SetPlayerCameraType(SamplePlayerCameraType.SIDE_SCROLLER);
            
            SetCam();
            
            SetWalkingState();
        }

        private void SetPlayerCameraType(SamplePlayerCameraType type)
        {
            playerCameraType = type;
        }
    }
}
