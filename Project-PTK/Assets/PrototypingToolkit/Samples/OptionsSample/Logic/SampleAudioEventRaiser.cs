using MyBox;
using PrototypingToolkit.Audio;
using UnityEngine;

namespace PrototypingToolkit.Samples
{
	public class SampleAudioEventRaiser : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private AudioData audioData;
		
		[SerializeField] private AudioEventData click;
		[SerializeField] private AudioEventData music;
		[SerializeField] private AudioEventData paper;
		
		private void OnEnable()
		{
			// PlayMusic();
		}
		
		[ButtonMethod]
		private void PlayMusic()
		{
			audioData.PlayAudioEvent.Raise(music);
		}
		
		[ButtonMethod]
		private void StopMusic()
		{
			audioData.StopAudioEvent.Raise(music);
		}
		
		[ButtonMethod]
		private void PlayClick()
		{
			audioData.PlayAudioEvent.Raise(click);
		}
		
		[ButtonMethod]
		private void PlayPaper()
		{
			audioData.PlayAudioEvent.Raise(paper);
		}
	}
}
