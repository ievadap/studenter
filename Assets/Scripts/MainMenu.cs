using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Text ScoreLabel;
    
    void Start()
    {
        if (PlayerPrefs.GetFloat("Highscore", -1f) == -1f) {
            PlayerPrefs.SetFloat("Highscore", 742f);
        }
        ScoreLabel.text = PlayerPrefs.GetFloat("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame() {
        Application.LoadLevel(1);
    }
}
