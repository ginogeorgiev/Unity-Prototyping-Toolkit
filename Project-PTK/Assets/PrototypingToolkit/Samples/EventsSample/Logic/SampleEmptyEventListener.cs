using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;

namespace PrototypingToolkit.Samples.Logic
{
	public class SampleEmptyEventListener : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private SampleEventDataContainer sampleEventDataContainer;
		
		[Header("External Refs")]
		[SerializeField] private GameObject cube;
		
		private void OnEnable()
		{
			sampleEventDataContainer.On.Register(CubeOn);
			sampleEventDataContainer.Off.Register(CubeOff);
		}

		private void OnDisable()
		{
			sampleEventDataContainer.On.Unregister(CubeOn);
			sampleEventDataContainer.Off.Unregister(CubeOff);
		}

		private void DoSome(FloatVariable floatVariable)
		{
			Debug.Log(floatVariable.Get());
		}

		private void CubeOn()
		{
			cube.SetActive(true);
			sampleEventDataContainer.OnEventCounter.AddToCurrent(1);
		}

		private void CubeOff()
		{
			cube.SetActive(false);
			sampleEventDataContainer.OnEventCounter.AddToCurrent(1);
		}
	}
}
