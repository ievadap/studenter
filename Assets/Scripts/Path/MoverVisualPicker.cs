using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Direction {
    Up,
    Down,
    Left,
    Right
};

public class MoverVisualPicker : MonoBehaviour
{
    public Direction CurrentDirection;
    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    private Dictionary<Direction, GameObject> _states = new Dictionary<Direction, GameObject>();
    private Vector2 _lastPosition = new Vector2();
    private Vector2 _deltaPosition = new Vector2();

    void Start() {
        _states[Direction.Up] = Up;
        _states[Direction.Down] = Down;
        _states[Direction.Left] = Left;
        _states[Direction.Right] = Right;
    }

    void Update() 
    {
        _deltaPosition = new Vector2(transform.position.x, transform.position.y) - _lastPosition;
        _lastPosition = new Vector2(transform.position.x, transform.position.y);
        Direction dir = Direction.Up;
        if (Mathf.Abs(_deltaPosition.x) > Mathf.Abs(_deltaPosition.y)) 
        {
            if (_deltaPosition.x >= 0) 
            {
                dir = Direction.Right;
            } else {
                dir = Direction.Left;
            }
        } else {
            if (_deltaPosition.y >= 0) 
            {
                dir = Direction.Up;
            } else {
                dir = Direction.Down;
            }
        }

        CurrentDirection = dir;
        SwitchState(dir);
    }

    private void SwitchState(Direction direction) {
        foreach (var state in _states)
        {
            state.Value.SetActive(direction == state.Key);
        }
    }
}
