using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPositioner : MonoBehaviour
{
    public Transform[] Positions;

    void Start() {
        transform.position = Positions[Random.Range(0, Positions.Length)].position;
    }
}
