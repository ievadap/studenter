using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public float AudioInitialDelayInterval;
    public float AudioRepetitionInterval;

    void Start() {
        InvokeRepeating("PlaySound", AudioInitialDelayInterval, AudioRepetitionInterval);
    }

    private void PlaySound() {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
