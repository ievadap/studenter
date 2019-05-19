using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomout : MonoBehaviour
{
    public GameObject GameOver;
    private float _t = 0;
    public float Target = 2f;

    private bool _isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAnimating)
        {
            _t += Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Target, _t);
            GameOver.transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Lerp(GameOver.transform.localScale.x, 4f, _t);
        }

    }

    public void StartZoom()
    {
        _t = 0;
        _isAnimating = true;
    }
}
