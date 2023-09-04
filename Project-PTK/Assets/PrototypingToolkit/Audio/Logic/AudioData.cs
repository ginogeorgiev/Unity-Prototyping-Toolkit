using PrototypingToolkit.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace PrototypingToolkit.Audio
{
	[CreateAssetMenu(
		menuName = PTK_MenuNames.MN_AOD,
		fileName = PTK_MenuNames.FN_AOD,
		order = PTK_MenuNames.O_OPTIONS)]
	public class AudioData : ScriptableObject
	{
		[Header("Data")]
		[SerializeField] private AudioMixer audioMixer;
		[SerializeField] private AudioEvent playAudioEvent;
		[SerializeField] private AudioEvent stopAudioEvent;

		// TODO serialized dictionary would be better here
		private const string master = "MasterVolume";
		private const string music = "MusicVolume";
		private const string sounds = "SoundsVolume";
		private const string ambience = "AmbienceVolume";
		private const string ui = "UIVolume";
		private const string voice = "VoiceVolume";
		
		[Header("Values")]
		[SerializeField] private AudioBoolVariable muteAudio;
		[SerializeField] private AudioBoolVariable muteAudioInBackground;
		
		[Header("")]
		[SerializeField] private VolumeFloatVariable masterVolume;
		[SerializeField] private VolumeFloatVariable musicVolume;
		[SerializeField] private VolumeFloatVariable soundsVolume;
		[SerializeField] private VolumeFloatVariable ambienceVolume;
		[SerializeField] private VolumeFloatVariable uiVolume;
		[SerializeField] private VolumeFloatVariable voiceVolume;

		public AudioMixer AudioMixer => audioMixer;
		public AudioEvent PlayAudioEvent => playAudioEvent;
		public AudioEvent StopAudioEvent => stopAudioEvent;

		public static string Master => master;
		public static string Music => music;
		public static string Sounds => sounds;
		public static string Ambience => ambience;
		public static string UI => ui;
		public static string Voice => voice;

		public AudioBoolVariable MuteAudio => muteAudio;
		public AudioBoolVariable MuteAudioInBackground => muteAudioInBackground;

		public VolumeFloatVariable MasterVolume => masterVolume;
		public VolumeFloatVariable MusicVolume => musicVolume;
		public VolumeFloatVariable AmbienceVolume => ambienceVolume;
		public VolumeFloatVariable SoundsVolume => soundsVolume;
		public VolumeFloatVariable UIVolume => uiVolume;
		public VolumeFloatVariable VoiceVolume => voiceVolume;
		
		
	}
}
