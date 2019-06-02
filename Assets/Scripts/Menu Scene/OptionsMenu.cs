using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private float musicVolume;
    private float sfxVolume;

    private Slider musicSlider;
    private Slider soundSlider;

    void Start()
    {
        musicSlider = GameObject.Find("Music slider").GetComponent<Slider>();
        soundSlider = GameObject.Find("Sound slider").GetComponent<Slider>();

        musicVolume = PlayerPrefs.GetFloat("musicVolume", 0);
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 0);

        musicSlider.value = musicVolume;
        soundSlider.value = sfxVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
        audioMixer.SetFloat("sfxVolume", volume);
        Debug.Log(sfxVolume.ToString());
    }
}
