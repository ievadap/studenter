using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]

public class TriggeredParticleEmission : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (particleSystem.isStopped)
            {
                particleSystem.Play();
            }
            else
            {
                particleSystem.Stop();

            }
        }
    }
}
