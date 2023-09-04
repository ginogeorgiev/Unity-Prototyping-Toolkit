using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Audio
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_AEFD,
		fileName = PTK_MenuNames.FN_AEFD,
		order = PTK_MenuNames.O_AUDIO)]
	public class AudioEmitterFactoryData : FactoryData<AudioEmitterBehaviour>
	{
		public AudioEmitterBehaviour prefab;

		public override AudioEmitterBehaviour Create()
		{
			return Instantiate(prefab);
		}
	}
}
