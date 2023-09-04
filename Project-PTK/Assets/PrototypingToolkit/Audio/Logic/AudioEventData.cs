using System;
using MyBox;
using PrototypingToolkit.Core;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace PrototypingToolkit.Audio
{
	[Serializable]
	public class AudioClipData
	{
		[SerializeField] private AudioClip audioClip;
		
		[MinMaxRange(0, 2)][SerializeField] private RangedFloat volume = new (1, 1);
		[MinMaxRange(0, 2)][SerializeField] private RangedFloat pitch = new (1, 1);
		[MinMaxRange(-1, 1)][SerializeField] private RangedFloat pan = new (0, 0);

		public AudioClip AudioClip => audioClip;
		public RangedFloat Volume => volume;
		public RangedFloat Pitch => pitch;
		public RangedFloat Pan => pan;
	}
	
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_AED,
		fileName = PTK_MenuNames.FN_AED,
		order = PTK_MenuNames.O_AUDIO)]
	public class AudioEventData : ScriptableObject
	{
		[SerializeField] private AudioMixerGroup audioGroup;
		
		[SerializeField] private bool looping;
		[SerializeField] private bool fadeIn;
		[ConditionalField(nameof(fadeIn))]
		[Range(0.01f,1f),SerializeField] private float fadeInMultiplier = 0.2f;
		[SerializeField] private bool fadeOutOnStop;
		[ConditionalField(nameof(fadeOutOnStop))]
		[Range(-1f,0.01f),SerializeField] private float fadeOutMultiplier = 0.2f;
		
		[SerializeField] private AudioClipData[] audioClips;

		public bool Looping => looping;
		public bool FadeIn => fadeIn;
		public float FadeInMultiplier => fadeInMultiplier;
		public bool FadeOutOnStop => fadeOutOnStop;
		public float FadeOutMultiplier => fadeOutMultiplier;

		public void Play(AudioSource source, out AudioClipData audioClipData)
		{
			audioClipData = null;
			if (audioClips.Length == 0) return;
			
			ApplyAudioValuesTo(source, out audioClipData);
			
			source.Play();
		}

		private void ApplyAudioValuesTo(AudioSource source, out AudioClipData audioClipData)
		{
			audioClipData = GetRandomClipData(audioClips);

			source.outputAudioMixerGroup = audioGroup;
			source.clip = audioClipData.AudioClip;
			source.loop = looping;
			source.time = 0f; // Needed Reset for different length of clips
			source.volume = Random.Range(audioClipData.Volume.Min, audioClipData.Volume.Max);
			source.pitch = Random.Range(audioClipData.Pitch.Min, audioClipData.Pitch.Max);
			source.panStereo = Random.Range(audioClipData.Pan.Min, audioClipData.Pan.Max);
		}

		private AudioClipData GetRandomClipData(AudioClipData[] audioClips)
		{
			AudioClipData audioClipData = audioClips[Random.Range(0, audioClips.Length)];
			return audioClipData;
		}
	}
}
