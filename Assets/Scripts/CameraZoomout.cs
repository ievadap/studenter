using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomout : MonoBehaviour
{
    public GameObject GameOver;
    public float Target = 2f;

    private float time = 0;
    private bool _isAnimating = false;

    void Update()
    {
        if (_isAnimating)
        {
            time += Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Target, time);
            GameOver.transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Lerp(GameOver.transform.localScale.x, 4f, time);
        }

    }

    public void StartZoom()
    {
        time = 0;
        _isAnimating = true;
    }
}
