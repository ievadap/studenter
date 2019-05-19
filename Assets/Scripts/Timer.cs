using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public UnityEngine.UI.Text TimerLabel;
    public float TimerCount = 60;
    private bool _isTimerActive = false;
    void Update() {
        if (_isTimerActive) {
            TimerCount -= Time.deltaTime;
        }

        if (TimerCount < 0) {
            TimerCount = 0;
            _isTimerActive = false;
            gameObject.GetComponent<Player>().TimerDone();
        }

        TimerLabel.text = "Time left: " + (int)TimerCount;
    }

    void ForceStopTimer() {
        _isTimerActive = false;
        TimerLabel.transform.parent.GetComponent<Animator>().enabled = false;
    }
    
    public void Resume() {
        _isTimerActive = true;
    }

    public void Stop() {
        _isTimerActive = false;
    }
}
