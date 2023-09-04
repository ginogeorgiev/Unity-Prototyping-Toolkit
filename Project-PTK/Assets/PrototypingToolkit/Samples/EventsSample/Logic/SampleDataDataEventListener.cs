using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
	public class SampleDataDataEventListener : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private SampleEventDataContainer eventDataContainer;
		
		private void OnEnable()
		{
			eventDataContainer.GOOn.Register(CubeOn);
			eventDataContainer.GOOff.Register(CubeOff);
		}
		
		private void OnDisable()
		{
			eventDataContainer.GOOn.Unregister(CubeOn);
			eventDataContainer.GOOff.Unregister(CubeOff);
		}

		private void CubeOn(SampleEventCubeBehaviour cube)
		{
			cube.gameObject.SetActive(true);
			eventDataContainer.OnEventCounter.AddToCurrent(1);
		}

		private void CubeOff(SampleEventCubeBehaviour cube)
		{
			cube.gameObject.SetActive(false);
			eventDataContainer.OnEventCounter.AddToCurrent(1);
		}
	}
}
