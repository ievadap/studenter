﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 _lastPos;

    void Update()
    {
        if (!gameObject.GetComponent<Player>().IsAlive) {
            gameObject.GetComponent<Animator>().SetFloat("Speed", 0f);
        }

        float speed = Vector3.Distance(transform.position, _lastPos);
        gameObject.GetComponent<Animator>().SetFloat("Speed", speed);
        _lastPos = transform.position;
    }
}
