using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Default Audio Settings")]
    [SerializeField]
    private bool    mute                = false;
    [SerializeField]
    private float   masterVolume        = 0.5f,
                    musicVolume         = 1f,
                    soundEffectsVolume  = 1f,
                    voicesVolume        = 1f;

    [Header("UI Elements")]
    [SerializeField]
    private Toggle  muteToggle;
    [SerializeField]
    private Slider  masterVolumeSlider,
                    musicVolumeSlider,
                    soundEffectsVolumeSlider,
                    voicesVolumeSlider;

    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource[] musicSources;
    [SerializeField]
    private AudioSource[] soundEffectSources;
    [SerializeField]
    private AudioSource[] voiceSources;

    private void Awake()
    {
        LoadPlayerPrefs();
    }

    private void Start()
    {
        InitializeUI();

        MuteAudioSources(musicSources,          mute);
        MuteAudioSources(soundEffectSources,    mute);
        MuteAudioSources(voiceSources,          mute);

        AdjustVolume(musicSources,          masterVolume * musicVolume);
        AdjustVolume(soundEffectSources,    masterVolume * soundEffectsVolume);
        AdjustVolume(voiceSources,          masterVolume * voicesVolume);
    }

    private void LoadPlayerPrefs()
    {
        mute                = PlayerPrefs.GetInt    ("Mute",                    mute ? 1 : 0) == 1;
        masterVolume        = PlayerPrefs.GetFloat  ("Master Volume",           masterVolume);
        musicVolume         = PlayerPrefs.GetFloat  ("Music Volume",            musicVolume);
        soundEffectsVolume  = PlayerPrefs.GetFloat  ("Sound Effects Volume",    soundEffectsVolume);
        voicesVolume        = PlayerPrefs.GetFloat  ("Voices Volume",           voicesVolume);
    }

    private void InitializeUI()
    {
        muteToggle.isOn                 = mute;
        masterVolumeSlider.value        = masterVolume;
        musicVolumeSlider.value         = musicVolume;
        soundEffectsVolumeSlider.value  = soundEffectsVolume;
        voicesVolumeSlider.value        = voicesVolume;
    }

    private void MuteAudioSources(AudioSource[] audioSources, bool mute)
    {
        foreach (AudioSource audioSource in audioSources)
            audioSource.mute = mute;
    }

    private void AdjustVolume(AudioSource[] audioSources, float volume)
    {
        foreach (AudioSource audioSource in audioSources)
            audioSource.volume = volume;
    }

    public void SetMute(bool value)
    {
        mute = value;
        PlayerPrefs.SetInt("Mute", mute ? 1 : 0);
        PlayerPrefs.Save();

        MuteAudioSources(musicSources,          mute);
        MuteAudioSources(soundEffectSources,    mute);
        MuteAudioSources(voiceSources,          mute);
    }

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        PlayerPrefs.SetFloat("Master Volume", masterVolume);
        PlayerPrefs.Save();

        AdjustVolume(musicSources,          masterVolume * musicVolume);
        AdjustVolume(soundEffectSources,    masterVolume * soundEffectsVolume);
        AdjustVolume(voiceSources,          masterVolume * voicesVolume);
    }
    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("Music Volume", musicVolume);
        PlayerPrefs.Save();
        AdjustVolume(musicSources, masterVolume * musicVolume);
    }
    public void SetSoundEffectsVolume(float value)
    {
        soundEffectsVolume = value;
        PlayerPrefs.SetFloat("Sound Effects Volume", soundEffectsVolume);
        PlayerPrefs.Save();
        AdjustVolume(soundEffectSources, masterVolume * soundEffectsVolume);
    }
    public void SetVoicesVolume(float value)
    {
        voicesVolume = value;
        PlayerPrefs.SetFloat("Voices Volume", voicesVolume);
        PlayerPrefs.Save();
        AdjustVolume(voiceSources, masterVolume * voicesVolume);
    }
}
