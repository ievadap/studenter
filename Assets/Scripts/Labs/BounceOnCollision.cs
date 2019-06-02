using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    public int maxBounces = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (maxBounces > 1)
        {
            maxBounces -= 1;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().material.bounciness = 0;
        }
    }
}
