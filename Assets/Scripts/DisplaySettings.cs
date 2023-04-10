using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
    [Header("Default Video Settings")]
    [SerializeField]
    private bool fullscreen = true;
    [SerializeField]
    private bool subtitles = false;
    [SerializeField]
    private int fontSize = 30;
    [SerializeField]
    private int resolutionIndex = 0;
//    [SerializeField]
  //  private float brightness = 1;

    [Header("UI Elements")]
    [SerializeField]
    private Toggle fullscreenToggle;
    [SerializeField]
    private Toggle subtitlesToggle;
    [SerializeField]
    private Slider fontSizeSlider;
    [SerializeField]
    private Dropdown resolutionDropdown;
//    [SerializeField]
  //  private Slider brightnessSlider;

    [Header("Display Game Objects")]
    [SerializeField]
    private Text subtitlesText;

    private Resolution[] supportedResolutions;
    private Resolution currentResolution;
    private int currentResolutionIndex;

    private void Awake()
    {
        currentResolution = Screen.currentResolution;
        supportedResolutions = Screen.resolutions;

        for(int i = 0; i != supportedResolutions.Length; ++i)
            if(supportedResolutions[i].Equals(currentResolution))
                currentResolutionIndex = i;

        LoadPlayerPrefs();
    }

    private void Start()
    {
        InitializeUI();
        InitializeDisplay();
    }

    private void LoadPlayerPrefs()
    {
        fullscreen = PlayerPrefs.GetInt("Fullscreen", fullscreen ? 1 : 0) == 1;
        subtitles = PlayerPrefs.GetInt("Subtitles", subtitles ? 1 : 0) == 1;
        fontSize = PlayerPrefs.GetInt("Font Size", fontSize);
        resolutionIndex = PlayerPrefs.GetInt("Resolution", currentResolutionIndex);
//        brightness = PlayerPrefs.GetFloat("Brightness", brightness);
    }

    private void InitializeUI()
    {
        resolutionDropdown.ClearOptions();

        List<Dropdown.OptionData> resolutionOptions = new List<Dropdown.OptionData>(supportedResolutions.Length);

        for(int i = 0; i !=  supportedResolutions.Length; ++i)
            resolutionOptions.Add(new Dropdown.OptionData(supportedResolutions[i].width + "x" + supportedResolutions[i].height));

        resolutionDropdown.AddOptions(resolutionOptions);

        fullscreenToggle.isOn = fullscreen;
        subtitlesToggle.isOn = subtitles;
        fontSizeSlider.value = fontSize;
        resolutionDropdown.value = resolutionIndex;
//        brightnessSlider.value = brightness;
    }

    private void InitializeDisplay()
    {
        subtitlesText.enabled = subtitles;
        subtitlesText.fontSize = fontSize;
        Screen.SetResolution(supportedResolutions[resolutionIndex].width, supportedResolutions[resolutionIndex].height, fullscreen);
//        Screen.brightness = brightness;
    }

    public void SetFullscreen(bool value)
    {
        fullscreen = value;
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.Save();
        Screen.fullScreen = fullscreen;
    }

    public void SetSubtitles(bool value)
    {
        subtitles = value;
        PlayerPrefs.SetInt("Subtitles", subtitles ? 1 : 0);
        PlayerPrefs.Save();
        subtitlesText.enabled = subtitles;
    }

    public void SetFontSize(float value)
    {
        fontSize = (int) value;
        PlayerPrefs.SetInt("Font Size", fontSize);
        PlayerPrefs.Save();
        subtitlesText.fontSize = fontSize;
    }

    public void SetResolution(int value)
    {
        resolutionIndex = value;
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
        PlayerPrefs.Save();
        Screen.SetResolution(supportedResolutions[resolutionIndex].width, supportedResolutions[resolutionIndex].height, fullscreen);
    }

/*    public void SetBrightness(float value)
    {
        brightness = value;
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
        Screen.brightness = brightness;
    }*/
}
