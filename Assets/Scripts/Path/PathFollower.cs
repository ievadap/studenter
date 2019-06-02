using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Path MainPath;
    public float Speed = 0.1f;
    public bool IsPingPong = false;

    private float _pathPosition;

    void Update()
    {
        _pathPosition += Speed * Time.deltaTime / MainPath.Length;
        if (!IsPingPong && _pathPosition > 1f) {
            _pathPosition -= 1f;
        }
        transform.position = MainPath.GetPointOnPath(Mathf.PingPong(_pathPosition, 1));
    }

    public void SetPathPosition(float position) {
        _pathPosition = position * (IsPingPong ? 2f : 1f);
    } 
}
