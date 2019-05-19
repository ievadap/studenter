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
        Vector3 force = new Vector3(RandomForce(), RandomForce(), RandomForce());
        gameObject.GetComponent<Rigidbody>().AddForce(force);
    }

    private float RandomForce()
    {
        return Random.Range(-forceRange, forceRange);
    }
}
