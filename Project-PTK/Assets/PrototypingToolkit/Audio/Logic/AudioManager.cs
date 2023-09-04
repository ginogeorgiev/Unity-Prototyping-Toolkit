using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypingToolkit.Audio
{
	public class AudioManager : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField] private AudioData audioData;
		[SerializeField] private AudioEmitterPoolData pool;
		
		[Header("Settings")]
		[SerializeField] private int initialPoolSize = 10;
		
		[Header("Debug")]
		[SerializeField] private List<AudioEmitterBehaviour> activeAudioEmitters = new ();

		private void Awake()
		{
			pool.Prewarm(initialPoolSize);
			pool.SetParent(transform);
		}

		private void OnEnable()
		{
			audioData.PlayAudioEvent.Register(PlayAudioRequest);
			audioData.StopAudioEvent.Register(StopAudioRequest);
		}

		private void OnDisable()
		{
			audioData.PlayAudioEvent.Unregister(PlayAudioRequest);
			audioData.StopAudioEvent.Unregister(StopAudioRequest);

			CleanAllEmitters();
		}

		private void CleanAllEmitters()
		{
			for (int i = activeAudioEmitters.Count - 1; i >= 0; i--)
			{
				CleanEmitter(activeAudioEmitters[i]);
			}
		}

		private void PlayAudioRequest(AudioEventData audioEventData)
		{
			AudioEmitterBehaviour audioEmitter = pool.Request();
			activeAudioEmitters.Insert(0, audioEmitter);
			audioEmitter.CurrentAudioEventData = audioEventData;
			audioEmitter.PlayAudioClip(audioEventData);
		}

		private void StopAudioRequest(AudioEventData audioEventData)
		{
			if (!audioEventData) return;
			
			for (int i = activeAudioEmitters.Count - 1; i >= 0; i--)
			{
				if (activeAudioEmitters[i].CurrentAudioEventData != audioEventData) continue;

				if (activeAudioEmitters[i].IsFadingOut) continue;

				if (audioEventData.FadeOutOnStop)
				{
					StartCoroutine(CleanEmitterWithFade(activeAudioEmitters[i]));
					return;
				}

				CleanEmitter(activeAudioEmitters[i]);
				return;
			}

			Debug.LogWarning($"Received Audio Stop-Request, but there is no AudioEmitter playing with {audioEventData.name}");
		}

		private IEnumerator CleanEmitterWithFade(AudioEmitterBehaviour audioEmitter)
		{
			yield return StartCoroutine(audioEmitter.StopWithFade());

			activeAudioEmitters.Remove(audioEmitter);
			pool.Return(audioEmitter);
		}

		private void CleanEmitter(AudioEmitterBehaviour audioEmitter)
		{
			audioEmitter.Stop();
			activeAudioEmitters.Remove(audioEmitter);
			pool.Return(audioEmitter);
		}
	}
}
