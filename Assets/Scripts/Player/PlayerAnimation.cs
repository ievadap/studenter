using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 _lastPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
