using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] public class Path : MonoBehaviour
{
    public List<Transform> PathPoints;
    public float Length
    {
        get { return _length; }
    }
    private float[] _lengths;
    [SerializeField] private float _length = 0f;
   
    void Start () {
        _length = GetLength();
    }
    
    void Update()
    {
        //#if UNITY_EDITOR
        //_length = GetLength();
        //for (int i = 0; i < PathPoints.Count - 1; i++) 
        //{
        //    if (PathPoints[i] != null && PathPoints[i + 1]) 
        //    {
        //        Debug.DrawLine(PathPoints[i].position, PathPoints[i + 1].position, Color.blue);
        //    }
        //}
        //#endif
    }

    private float GetLength() 
    {
        float length = 0f;
        _lengths = new float[PathPoints.Count];
        for (int i = 0; i < PathPoints.Count - 1; i++) 
        {
            if (PathPoints[i] != null && PathPoints[i + 1]) 
            {
                float lineLength = Vector2.Distance(PathPoints[i].position, PathPoints[i + 1].position);
                length += lineLength;
                _lengths[i] = lineLength;
            }
        }
        return length;
    }

    public Vector2 GetPointOnPath(float normalizedPosition) 
    {
        normalizedPosition = Mathf.Clamp01(normalizedPosition);
        var position = normalizedPosition * _length;
        for (int i = 0; i < _lengths.Length; i++) 
        {
            if (position > _lengths[i]) {
                position -= _lengths[i];
            } else {
                var normalizedLinePosition = position / _lengths[i];
                return Vector2.Lerp(PathPoints[i].position, PathPoints[i + 1].position, normalizedLinePosition);
            }
        }
        return new Vector2();
    }
}
