using PrototypingToolkit.Audio;
using PrototypingToolkit.Core;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingToolkit.Options.Logic
{
	[RequireComponent(typeof(Slider))]
	public class AudioSliderBehaviour : MonoBehaviour
	{
		[BetterTooltip("Choose which Volume is going to be changed with this slider")]
		[SerializeField] private VolumeFloatVariable volumeFloat;
		
		public void OnSliderValueChanged(float value)
		{
			volumeFloat.Set(value);
		}
	}
}
