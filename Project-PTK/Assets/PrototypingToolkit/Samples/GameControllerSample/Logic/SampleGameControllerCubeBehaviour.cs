using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Samples.Logic
{
	public class SampleGameControllerCubeBehaviour : MonoBehaviour
	{
		[Header("Hi")]
		[SerializeField] private IntVariable clickAmount;
		[SerializeField] private InputActionMap input;
		
		private Camera mainCamera;
		private InputAction clickAction;
		public IntVariable ClickAmount => clickAmount;
		public Rigidbody CubeRigidbody { get; private set; }

		private void Awake()
		{
			mainCamera = Camera.main;
			CubeRigidbody = GetComponent<Rigidbody>();
			clickAction = input["Click"];
		}
		
		private void OnEnable()
		{
			input.Enable();
			clickAction.performed += OnClick;
		}

		private void OnDisable()
		{
			clickAction.performed -= OnClick;
			input.Disable();
		}

		private void OnClick(InputAction.CallbackContext context)
		{
			Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

			if (!Physics.Raycast(ray, out RaycastHit hit) || hit.collider.gameObject != gameObject) return;
			
			clickAmount.Set(clickAmount.Get() + 1);
			Vector3 torqueDirection = hit.point - CubeRigidbody.worldCenterOfMass;

			CubeRigidbody.AddTorque(torqueDirection.normalized * 50f);
		}
	}
}
