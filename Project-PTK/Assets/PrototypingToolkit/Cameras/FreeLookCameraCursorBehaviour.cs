using UnityEngine;

namespace PrototypingToolkit.Cameras
{
	public class FreeLookCameraCursorBehaviour : MonoBehaviour
	{
		private void OnEnable()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
