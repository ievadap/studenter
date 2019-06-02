using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public UnityEngine.UI.Text ScoreLabel;
    
    void Start()
    {
        ScoreLabel.text = PlayerPrefs.GetFloat("Highscore", 0).ToString();

        audioMixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume", 0));
        audioMixer.SetFloat("sfxVolume", PlayerPrefs.GetFloat("sfxVolume", 0));
    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
