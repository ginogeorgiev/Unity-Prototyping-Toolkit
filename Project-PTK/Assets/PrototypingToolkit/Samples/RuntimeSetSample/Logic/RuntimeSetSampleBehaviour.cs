using MyBox;
using UnityEngine;

namespace PrototypingToolkit.Samples
{
	public class RuntimeSetSampleBehaviour : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private SampleRuntimeSet sampleRuntimeSet;
		
		private void OnEnable()
		{
			sampleRuntimeSet.Add(this);
		}
		
		private void OnDestroy()
		{
			sampleRuntimeSet.Remove(this);
		}
		
		[ButtonMethod]
		private void AllOn()
		{
			sampleRuntimeSet.AllOn();
		}
		
		[ButtonMethod]
		private void AllOff()
		{
			sampleRuntimeSet.AllOff();
		}
	}
}
