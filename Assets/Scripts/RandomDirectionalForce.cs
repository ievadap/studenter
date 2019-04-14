using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirectionalForce : MonoBehaviour
{
    public float forceRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ApplyRandomForce", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyRandomForce()
    {
        gameObject
            .GetComponent<Rigidbody>()
            .AddForce(new Vector3(Random.Range(-forceRange, forceRange), Random.Range(-forceRange, forceRange), Random.Range(-forceRange, forceRange)));
    }
}
