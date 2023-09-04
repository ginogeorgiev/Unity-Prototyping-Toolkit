using PrototypingToolkit.Audio;
using PrototypingToolkit.Core;
using PrototypingToolkit.InputControls;
using UnityEngine;

namespace PrototypingToolkit.UI.Options
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_OD,
		fileName = PTK_MenuNames.FN_OD,
		order = PTK_MenuNames.O_OPTIONS)]
	public class OptionsData : ScriptableObject
	{
		[Header("Data")]
		[SerializeField] private AudioData audioData;
		[SerializeField] private InputRebindData inputRebindData;

		public AudioData AudioData => audioData;
		public InputRebindData InputRebindData => inputRebindData;
	}
}
