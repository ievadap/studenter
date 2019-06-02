using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Player player;
    public UnityEngine.UI.Text TimerLabel;
    public float TimerCount = 60;

    private bool isTimerActive = false;
    private string labelText = "Time left: ";

    void Start()
    {
        TimerCount = Random.Range(TimerCount / 2, TimerCount);
    }

    void Update() {
        if (isTimerActive) {
            TimerCount -= Time.deltaTime;
        }

        if (TimerCount < 0) {
            TimerCount = 0;
            isTimerActive = false;
            player.TimerDone();
        }

        TimerLabel.text = labelText + (int)TimerCount;
    }
    
    public void Resume() {
        isTimerActive = true;
    }

    public void Stop() {
        isTimerActive = false;
        if (player.HasBook)
        {
            labelText = "Score: ";
        }
    }
}
