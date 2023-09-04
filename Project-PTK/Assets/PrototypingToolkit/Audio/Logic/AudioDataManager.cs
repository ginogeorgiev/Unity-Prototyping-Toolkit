using UnityEditor;
using UnityEngine;

namespace PrototypingToolkit.Audio
{
    public class AudioDataManager : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private AudioData audioData;

        private bool ifMutedInBackground;
        private bool isGameViewFocused;
        private bool prevIsGameViewFocused;

        private void Update()
        {
            HandleIfMutedInBackgroundHasChanged();
        }

        private void HandleIfMutedInBackgroundHasChanged()
        {
            if (!ifMutedInBackground || audioData.MuteAudio.Get()) return;
            
#if UNITY_EDITOR
            // Check if the Game View is focused in the Editor
            isGameViewFocused = EditorApplication.isPlaying;
#endif
            // // Check if the Game View is focused in builds
            isGameViewFocused = Application.isFocused;

            if (isGameViewFocused == prevIsGameViewFocused) return;
            prevIsGameViewFocused = isGameViewFocused;

            if (!isGameViewFocused && audioData.MuteAudioInBackground.Get())
            {
                audioData.AudioMixer.SetFloat(AudioData.Master, -80f);
            }
            else
            {
                audioData.AudioMixer.SetFloat(AudioData.Master, Mathf.Log10(audioData.MasterVolume.Get()) * 20);
            }
        }

        private void OnEnable()
        {
            audioData.MuteAudio.OnCurrentChanged.Register(OnMuteChanged);
            audioData.MuteAudioInBackground.OnCurrentChanged.Register(OnMuteInBackgroundChanged);

            audioData.MasterVolume.OnCurrentChanged.Register(OnMasterVolumeChanged);
            audioData.MusicVolume.OnCurrentChanged.Register(OnMusicVolumeChanged);
            audioData.SoundsVolume.OnCurrentChanged.Register(OnSoundsVolumeChanged);
            audioData.AmbienceVolume.OnCurrentChanged.Register(OnAmbienceVolumeChanged);
            audioData.UIVolume.OnCurrentChanged.Register(OnUIVolumeChanged);
            audioData.VoiceVolume.OnCurrentChanged.Register(OnVoiceVolumeChanged);

            ApplyAudioSettings();
        }

        private void ApplyAudioSettings()
        {
            OnMuteChanged();
            OnMasterVolumeChanged();
            OnMusicVolumeChanged();
            OnSoundsVolumeChanged();
            OnAmbienceVolumeChanged();
            OnUIVolumeChanged();
            OnVoiceVolumeChanged();
        }

        private void OnDisable()
        {
            audioData.MuteAudio.OnCurrentChanged.Unregister(OnMuteChanged);
            audioData.MuteAudioInBackground.OnCurrentChanged.Unregister(OnMuteInBackgroundChanged);

            audioData.MasterVolume.OnCurrentChanged.Unregister(OnMasterVolumeChanged);
            audioData.MusicVolume.OnCurrentChanged.Unregister(OnMusicVolumeChanged);
            audioData.SoundsVolume.OnCurrentChanged.Unregister(OnSoundsVolumeChanged);
            audioData.AmbienceVolume.OnCurrentChanged.Unregister(OnAmbienceVolumeChanged);
            audioData.UIVolume.OnCurrentChanged.Unregister(OnUIVolumeChanged);
            audioData.VoiceVolume.OnCurrentChanged.Unregister(OnVoiceVolumeChanged);
        }

        private void OnMuteChanged()
        {
            if (audioData.MuteAudio.Get())
            {
                audioData.AudioMixer.SetFloat(AudioData.Master, -80f);
            }
            else
            {
                audioData.AudioMixer.SetFloat(AudioData.Master, Mathf.Log10(audioData.MasterVolume.Get()) * 20);
            }
        }

        private void OnMuteInBackgroundChanged()
        {
            ifMutedInBackground = audioData.MuteAudioInBackground.Get();
        }

        private void OnMasterVolumeChanged()
        {
            if (audioData.MuteAudio.Get()) return;

            audioData.AudioMixer.SetFloat(AudioData.Master, Mathf.Log10(audioData.MasterVolume.Get()) * 20);
        }

        private void OnMusicVolumeChanged()
        {
            audioData.AudioMixer.SetFloat(AudioData.Music, Mathf.Log10(audioData.MusicVolume.Get()) * 20);
        }

        private void OnSoundsVolumeChanged()
        {
            audioData.AudioMixer.SetFloat(AudioData.Sounds, Mathf.Log10(audioData.SoundsVolume.Get()) * 20);
        }

        private void OnAmbienceVolumeChanged()
        {
            audioData.AudioMixer.SetFloat(AudioData.Ambience, Mathf.Log10(audioData.AmbienceVolume.Get()) * 20);
        }

        private void OnUIVolumeChanged()
        {
            audioData.AudioMixer.SetFloat(AudioData.UI, Mathf.Log10(audioData.UIVolume.Get()) * 20);
        }

        private void OnVoiceVolumeChanged()
        {
            audioData.AudioMixer.SetFloat(AudioData.Voice, Mathf.Log10(audioData.VoiceVolume.Get()) * 20);
        }
    }
}
