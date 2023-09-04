using PrototypingToolkit.Audio;
using PrototypingToolkit.Core;
using UnityEngine;

namespace PrototypingToolkit.Options.Logic
{
	public class AudioToggleBehaviour : MonoBehaviour
	{
		[BetterTooltip("Choose which Bool is going to be changed with this toggle")]
		[SerializeField] private AudioBoolVariable audioBool;
		
		public void OnToggleValueChanged(bool value)
		{
			audioBool.Set(value);
		}
	}
}
