using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PrototypingToolkit.Audio
{
	public class AudioEmitterBehaviour : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private AudioData audioData;
		
		[Header("Internal Refs")]
		[SerializeField] private AudioSource audioSource;
		
		[Header("Debug")]
		[SerializeField] private AudioEventData currentAudioEventData;
		[SerializeField] private bool isFadingOut;
		public bool IsFadingOut => isFadingOut;

		private Coroutine fade;

		public AudioEventData CurrentAudioEventData
		{
			get => currentAudioEventData;
			set => currentAudioEventData = value;
		}

		private void Awake()
		{
			audioSource.playOnAwake = false;
		}

		public void PlayAudioClip(AudioEventData audioEventData)
		{
			audioEventData.Play(audioSource, out AudioClipData audioClipData);

			AudioClip audioClip = audioClipData.AudioClip;

			if (audioEventData.FadeIn)
			{
				audioSource.volume = 0;
				fade = StartCoroutine(DoFade(
					Random.Range(audioClipData.Volume.Min, audioClipData.Volume.Max),
					currentAudioEventData.FadeInMultiplier));
			}

			if (audioClip != null && !audioEventData.Looping)
			{
				StartCoroutine(StopAfterPlaying(audioClip.length));
			}
		}

		private IEnumerator StopAfterPlaying(float clipLength)
		{
			yield return new WaitForSeconds(clipLength);

			audioData.StopAudioEvent.Raise(currentAudioEventData);
		}

		public void Stop()
		{
			audioSource.Stop();
			currentAudioEventData = null;
		}

		public IEnumerator StopWithFade()
		{
			isFadingOut = true;
			
			StopCoroutine(fade);
			yield return DoFade(0f, currentAudioEventData.FadeOutMultiplier);
			
			audioSource.Stop();
			currentAudioEventData = null;
			isFadingOut = false;
		}
	
		public void Pause()
		{
			audioSource.Pause();
		}
		
		public void Resume()
		{
			audioSource.Play();
		}

		public bool IsPlaying()
		{
			return audioSource.isPlaying;
		}

		public void FadeInAudioClip()
		{
			
		}
		
		private IEnumerator DoFade(float goalVolume, float multiplier = 0.1f)
		{
			float currentVol = audioSource.volume;
			while (Math.Abs(audioSource.volume - goalVolume) > 0.01f)
			{
				audioSource.volume = currentVol;
				currentVol += Time.deltaTime * multiplier;
				yield return new WaitForEndOfFrame();
			}

			audioSource.volume = goalVolume;
		}
	}
}
