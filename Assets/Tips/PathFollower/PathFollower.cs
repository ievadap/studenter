using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Path MainPath;

    private float _pathPosition;
    public float Speed = 0.1f;
    public bool IsWorldSpeed = false;
    public bool IsRotating = false;
    public bool IsPingPong = false;

    // Update is called once per frame
    void Update()
    {
        if (!IsWorldSpeed) {
            _pathPosition += Speed * Time.deltaTime;
        } else {
            _pathPosition += Speed * Time.deltaTime / MainPath.Length;
        }

        if (!IsPingPong && _pathPosition > 1f) {
            _pathPosition -= 1f;
        }

        transform.position = MainPath.GetPointOnPath(Mathf.PingPong(_pathPosition, 1));
        if (IsRotating) {
             transform.LookAt(MainPath.GetNextPoint(_pathPosition), new Vector3(0f, 1f, 0f));
        }
    }

    public void SetPathPosition(float position) {
        _pathPosition = position * (IsPingPong ? 2f : 1f);
    } 
}
