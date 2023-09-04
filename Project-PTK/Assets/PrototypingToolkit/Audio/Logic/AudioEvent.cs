using PrototypingToolkit.Audio;
using UnityEngine;

namespace PrototypingToolkit.Core
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_AE,
		fileName = PTK_MenuNames.FN_AE, 
		order = PTK_MenuNames.O_EVENTS)]
	public class AudioEvent : DataEvent<AudioEventData> { }
}
