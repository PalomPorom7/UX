using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  Notes:
 *  I have no idea how to change the audio output device
 */
public class SoundSettings : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic,
                        soundEffectsSource;

    [SerializeField]
    private Slider  masterVolumeSlider,
                    soundEffectsSlider,
                    musicVolumeSlider,
                    voiceVolumeSlider;
    [SerializeField]
    private SelectionSetting soundOutputSelector;

    [Header("Default Sounds Settings")]
    [SerializeField]
    private float masterVolume = 0.5f;
    [SerializeField]
    private float soundEffects = 0.5f;
    [SerializeField]
    private float musicVolume = 0.5f;
    [SerializeField]
    private float voiceVolume = 0.5f;
    [SerializeField]
    private int soundOutput = 0;

    private void Awake()
    {
        LoadPrefs();
        Initialize();
    }

    private void LoadPrefs()
    {
        masterVolume    = PlayerPrefs.GetFloat  ("Master Volume",   masterVolume);
        soundEffects    = PlayerPrefs.GetFloat  ("Sound Effects",   soundEffects);
        musicVolume     = PlayerPrefs.GetFloat  ("Music Volume",    musicVolume);
        voiceVolume     = PlayerPrefs.GetFloat  ("Voice Volume",    voiceVolume);
        soundOutput     = PlayerPrefs.GetInt    ("Sound Output",    soundOutput);

        masterVolumeSlider.value = masterVolume;
        soundEffectsSlider.value = soundEffects;
        musicVolumeSlider.value = musicVolume;
        voiceVolumeSlider.value = voiceVolume;
        soundOutputSelector.SetInitialValue(soundOutput);
    }

    private void Initialize()
    {
        backgroundMusic.volume = musicVolume * masterVolume;
        soundEffectsSource.volume = soundEffects * masterVolume;
        // initialize sound output
    }

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        PlayerPrefs.SetFloat("Master Volume", value);
        backgroundMusic.volume = musicVolume * masterVolume;
        soundEffectsSource.volume = soundEffects * masterVolume;
        PlayerPrefs.Save();
    }

    public void SetSoundEffects(float value)
    {
        soundEffects = value;
        PlayerPrefs.SetFloat("Sound Effects", value);
        soundEffectsSource.volume = soundEffects * masterVolume;
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value)
    {
        masterVolume = value;
        PlayerPrefs.SetFloat("Music Volume", value);
        backgroundMusic.volume = musicVolume * masterVolume;
        PlayerPrefs.Save();
    }

    public void SetVoiceVolume(float value)
    {
        masterVolume = value;
        PlayerPrefs.SetFloat("Voice Volume", value);
        PlayerPrefs.Save();
    }

    public void SetSoundOutput(int value)
    {
        soundOutput = value;
        PlayerPrefs.SetInt("Sound Output", value);
        //  change sound output
        PlayerPrefs.Save();
    }
}
