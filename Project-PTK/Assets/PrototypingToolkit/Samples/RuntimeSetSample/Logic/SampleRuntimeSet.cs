using MyBox;
using PrototypingToolkit.Core;

namespace PrototypingToolkit.Samples
{
	public class SampleRuntimeSet : RuntimeSet<RuntimeSetSampleBehaviour>
	{
		[ButtonMethod]
		public void AllOn()
		{
			foreach (RuntimeSetSampleBehaviour runtimeSetSampleBehaviour in GetItems())
			{
				runtimeSetSampleBehaviour.gameObject.SetActive(true);
			}
		}
		
		[ButtonMethod]
		public void AllOff()
		{
			foreach (RuntimeSetSampleBehaviour runtimeSetSampleBehaviour in GetItems())
			{
				runtimeSetSampleBehaviour.gameObject.SetActive(false);
			}
		}
	}
}
