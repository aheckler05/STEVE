using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("masterVol") || PlayerPrefs.HasKey("musicVol") || PlayerPrefs.HasKey("sfxVol"))
        {
            loadVolume();
        } else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
            loadVolume();
        }
    }
    public void SetMasterVolume()
    {
        float vol = masterSlider.value;
        mixer.SetFloat("master", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("masterVol", vol);
    }
    public void SetMusicVolume()
    {
        float vol = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("musicVol", vol);
    }
    public void SetSFXVolume()
    {
        float vol = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("sfxVol", vol);
    }

    private void loadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
    }
}
