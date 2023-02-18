using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    #region Property
    private Object _object;
    private Vector3 _nextPos;
    #endregion

    #region Constructor
    private void Awake()
    {
        _object = this.transform.GetComponentInParent<Object>();
        _nextPos = Vector3.zero;
    }
    #endregion

    #region Method
    public void Move(Vector3 axis)
    {
        _object.transform.position = GetNextPos(axis);
        _nextPos = Vector3.zero;
    }

    private Vector3 GetNextPos(Vector3 axis)
    {
        Vector3 objectInScreen = Camera.main.WorldToScreenPoint(_object.transform.position);
        Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectInScreen.z));

        float x = (float)(Math.Floor(v.x / 0.5) * 0.5);
        float y = (float)(Math.Floor(v.y / 0.5) * 0.5);
        float z = (float)(Math.Floor(v.z / 0.5) * 0.5);
        if (y <= 0) { y = _object.Height; }

        _nextPos = _object.transform.position;
        if (axis.x != 0) { _nextPos.x = x; }
        if (axis.y != 0) { _nextPos.y = y; }
        if (axis.z != 0) { _nextPos.z = z; }

        return _nextPos;
    }
    #endregion

    #region Event
    
    #endregion
}
