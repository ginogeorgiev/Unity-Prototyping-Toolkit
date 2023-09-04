#if UNITY_EDITOR
using UnityEngine;

namespace PrototypingToolkit.Core
{
	[ExecuteInEditMode]
	public class FrameRateHandler : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private int frameRate;

		private int vSyncCount;
		private int targetFrameRate;
		
		private void OnEnable()
		{
			vSyncCount = QualitySettings.vSyncCount;
			targetFrameRate = Application.targetFrameRate;
			
			SetFrameRate();
		}

		private void OnValidate()
		{
			SetFrameRate();
		}

		private void SetFrameRate()
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = frameRate;
		}

		private void OnDisable()
		{
			QualitySettings.vSyncCount = vSyncCount;
			Application.targetFrameRate = targetFrameRate;
		}
	}
}
#endif
