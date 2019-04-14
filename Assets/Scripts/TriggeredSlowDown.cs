using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TriggeredSlowDown : MonoBehaviour
{
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            float playerSpeed = other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier;
            other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = playerSpeed / 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            float playerSpeed = other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier;
            other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = playerSpeed * 2;
        }
    }
}
