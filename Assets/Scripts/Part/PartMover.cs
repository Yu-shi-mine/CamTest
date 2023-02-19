using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMover : MonoBehaviour
{
    #region Property
    private Part _part;
    private Vector3 _nextPos;
    private float _positionIntervalXZ = 0.5f;
    private float _positionIntervalY = 0.2f;
    private float _yPosShift = 0.1f;
    #endregion

    #region Constructor
    private void Awake()
    {
        _part = this.transform.GetComponentInParent<Part>();
        _nextPos = Vector3.zero;
    }
    #endregion

    #region Method
    public void Move(Vector3 axis)
    {
        _part.transform.position = GetNextPos(axis);
        _nextPos = Vector3.zero;
    }

    private Vector3 GetNextPos(Vector3 axis)
    {
        Vector3 v = Camera.main.WorldToScreenPoint(this.transform.position);
        v = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, v.z));

        _nextPos = _part.transform.position;
        if (axis == Vector3.right)      { _nextPos.x = RoundHalfUp(v.x, _positionIntervalXZ); }
        if (axis == Vector3.up)         { _nextPos.y = RoundHalfUp(v.y, _positionIntervalY) + _yPosShift; }
        if (axis == Vector3.forward)    { _nextPos.z = RoundHalfUp(v.z, _positionIntervalXZ); }

        if (_nextPos.y <= _part.Height) { _nextPos.y = _part.Height; }
        return _nextPos;
    }

    private float RoundHalfUp(float value, float interval)
    {
        return (float)(Math.Floor(value / interval) * interval);
    }
    #endregion

    #region Event
    
    #endregion
}
