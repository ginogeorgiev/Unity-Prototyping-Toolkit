using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Cameras
{
    [CreateAssetMenu(
        menuName = PTK_MenuNames.MN_RTS,
        fileName = PTK_MenuNames.FN_RTS,
        order = PTK_MenuNames.O_CAMERAS)]
    public class RTSCameraData : ScriptableObject
    {
        [Header("Settings - Start Values")]
        [SerializeField] private bool useStartValues;
        [SerializeField] private Vector3 startPosition = new(0, 0, 0);
        [SerializeField] private Vector3 startRotation = new(45, 0, 0);
        [SerializeField] private float startFov = 40;
        
        [Header("Settings - Movement")]
        [SerializeField] private float panSpeed = 20f;
        [SerializeField] private bool mousePan = true;
        [SerializeField] private float panBorderThicknessPercentage = 10f;
        [SerializeField] private float speedUpMultiplier = 1f;
        
        [Header("Settings - Rotation")]
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private bool steppedRotation;
        [SerializeField] private float rotationStepAngle = 90;
        
        [Header("Settings - Zooming")]
        [SerializeField] private float zoomSpeed = 500f;
        [SerializeField] private Vector2 minMaxZoom = new (10f, 120f);

        public bool UseStartValues => useStartValues;
        public Vector3 StartPosition
        {
            get => startPosition;
            set => startPosition = value;
        }

        public Vector3 StartRotation
        {
            get => startRotation;
            set => startRotation = value;
        }

        public float StartFov
        {
            get => startFov;
            set => startFov = value;
        }

        public float PanSpeed => panSpeed;
        public bool MousePan => mousePan;
        public float PanBorderThicknessPercentage => panBorderThicknessPercentage;
        public float SpeedUpMultiplier => speedUpMultiplier;

        public float RotationSpeed => rotationSpeed;
        public bool SteppedRotation => steppedRotation;
        public float RotationStepAngle => rotationStepAngle;

        public float ZoomSpeed => zoomSpeed;
        public Vector2 MinMaxZoom => minMaxZoom;
    }
}
