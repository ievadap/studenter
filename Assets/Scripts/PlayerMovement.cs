using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Player>().IsAlive) {
            RecordPlayerInputs();
        }
    }

    void RecordPlayerInputs()
    { 
        Vector2 direction = new Vector2();
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            direction += new Vector2(-1, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector2(0, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += new Vector2(1, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += new Vector2(0, -1);
        }

        MovePlayer(direction);
    }

    void MovePlayer(Vector2 direction)
    {
        direction = direction.normalized * speed;
        transform.position += new Vector3(direction.x, direction.y, 0);
    }
}
