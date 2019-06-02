using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pidgeon : MonoBehaviour
{

    public float Speed;
    private float _t = 0f;
    private float _distance;
    private Vector3 _lastPos;
    private Vector3 _targetPos;

    void Start()
    {
        GetNewPos();
    }

    void Update()
    {
        _t += Time.deltaTime * Speed / _distance;
        transform.position = Vector3.Lerp(_lastPos, _targetPos, _t);
        if (_t > 1f) {
            _t = 0f;
            GetNewPos();
        }
    }

    private void GetNewPos() {
        _targetPos = Player.instance.transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        _lastPos = transform.position;
        _distance = Vector3.Distance(_lastPos, _targetPos);
    }
}
