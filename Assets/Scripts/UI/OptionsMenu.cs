using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Image gammaPanel;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider gammaSlider;
    public Toggle fullscreenToggle;

    void Start()
    {
        LoadOptions();
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    
    public void UpdateGammaValue(float gamma)
    {
        gammaPanel.color = new Color(
            gammaPanel.color.r, 
            gammaPanel.color.g, 
            gammaPanel.color.b, 
            gamma);
        PlayerPrefs.SetFloat("Gamma", gamma);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void SaveOptions()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

        float gamma = gammaPanel.color.a;
        PlayerPrefs.SetFloat("Gamma", gamma);

        bool fullscreen = Screen.fullScreen;
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
    }

    public void LoadOptions()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        gammaSlider.value = PlayerPrefs.GetFloat("Gamma");
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen") == 1 ? true : false;
    }
}
