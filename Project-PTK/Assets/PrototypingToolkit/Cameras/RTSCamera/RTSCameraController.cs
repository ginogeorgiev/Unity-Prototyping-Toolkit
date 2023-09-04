using Cinemachine;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Cameras
{
    public class RTSCameraController : MonoBehaviour
    {
        [Header("Data", order = 1)]
        [SerializeField] private RTSCameraData camData;
        [SerializeField] private InputActionMap input;
        
        [Header("Internal-Refs", order = 2)]
        [SerializeField] private Transform cameraFollowTarget;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        [Foldout("Debug", true, order = 3)]
        [SerializeField] private Vector2 movementInput;
        [SerializeField] private Vector3 movementDelta;
        
        [SerializeField] private float rotationInput;
        [SerializeField] private float rotationDelta;
        
        [SerializeField] private float steppedRotationInput;
        [SerializeField] private float steppedRotationDelta;
        
        [SerializeField] private float zoomInput;
        [SerializeField] private float fov;
        
        [SerializeField] private float speedUpInput;
        [SerializeField] private float speedUp;

        private void OnEnable()
        {
            if (camData.UseStartValues)
            {
                ResetCamera();
            }
            
            input.Enable();
            input["Rotation"].started += HandelSteppedRotation;
            input["ResetCamera"].started += HandelResetCamera;
        }

        private void OnDisable()
        {
            input.Disable();
            input["Rotation"].started -= HandelSteppedRotation;
            input["ResetCamera"].started -= HandelResetCamera;
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
            HandleZooming();
            HandleSpeedUp();
        }

        private void HandelResetCamera(InputAction.CallbackContext context)
        {
            ResetCamera();
        }

        private void ResetCamera()
        {
            cameraFollowTarget.position = camData.StartPosition;
            cameraFollowTarget.eulerAngles = camData.StartRotation;
            virtualCamera.m_Lens.FieldOfView = camData.StartFov;
        }


        private void HandleSpeedUp()
        {
            speedUpInput = input["SpeedUp"].ReadValue<float>();

            speedUp = speedUpInput > 0 ? camData.SpeedUpMultiplier : 1f;
        }

        private void HandleMovement()
        {
            movementInput = input["Movement"].ReadValue<Vector2>();

            movementDelta = new Vector3(
                movementInput.x * camData.PanSpeed * speedUp * Time.deltaTime,
                0,
                movementInput.y * camData.PanSpeed * speedUp * Time.deltaTime);

            movementDelta = Quaternion.Euler(0, cameraFollowTarget.eulerAngles.y, 0) * movementDelta; 
                
            cameraFollowTarget.position += movementDelta;
        }

        private void HandleRotation()
        {
            if (camData.SteppedRotation) return;
            
            rotationInput = input["Rotation"].ReadValue<float>();

            rotationDelta = rotationInput * camData.RotationSpeed * Time.deltaTime;
            
            Vector3 rotation = cameraFollowTarget.eulerAngles;
            rotation.y -= rotationDelta;
            cameraFollowTarget.eulerAngles = rotation;
        }

        private void HandelSteppedRotation(InputAction.CallbackContext context)
        {
            if (!camData.SteppedRotation) return;
            
            steppedRotationInput = context.ReadValue<float>();
            
            if (steppedRotationInput > 0)
            {
                Vector3 rotation = cameraFollowTarget.eulerAngles;
                rotation.y -= camData.RotationStepAngle;
                cameraFollowTarget.eulerAngles = rotation;
            }
            else if (steppedRotationInput < 0)
            {
                Vector3 rotation = cameraFollowTarget.eulerAngles;
                rotation.y += camData.RotationStepAngle;
                cameraFollowTarget.eulerAngles = rotation;
            }
        }

        private void HandleZooming()
        {
            zoomInput = input["Zooming"].ReadValue<float>();

            if (zoomInput == 0) return;
            
            fov = virtualCamera.m_Lens.FieldOfView;
            fov -= zoomInput * camData.ZoomSpeed * Time.deltaTime;
            fov = Mathf.Clamp(fov, camData.MinMaxZoom.x, camData.MinMaxZoom.y);

            virtualCamera.m_Lens.FieldOfView = fov;
        }
    }
}
