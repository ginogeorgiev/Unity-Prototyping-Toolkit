using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Audio
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_AEPD,
		fileName = PTK_MenuNames.FN_AEPD,
		order = PTK_MenuNames.O_AUDIO)]
	public class AudioEmitterPoolData : ComponentPoolData<AudioEmitterBehaviour>
	{
		[SerializeField] private AudioEmitterFactoryData factory;

		public override IFactory<AudioEmitterBehaviour> Factory
		{
			get => factory;
			set => factory = value as AudioEmitterFactoryData;
		}
	}
}
