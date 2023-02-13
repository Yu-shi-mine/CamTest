using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    #region Property
    [SerializeField] private Block _block;
    [SerializeField] private bool _x;
    [SerializeField] private bool _y;
    [SerializeField] private bool _z;

    Vector3 _presentPos;
    Vector3 _nextPos;
    #endregion

    #region Constructor
    private void Awake()
    {
        _nextPos = Vector3.zero;
    }
    #endregion

    #region Method
    private void Update()
    {
        _presentPos = _block.transform.position;
    }

    private Vector3 _getNextPos(float x, float y, float z)
    {
        Vector3 nextPos = _block.transform.position;
        if (_x) { nextPos.x = x; }
        if (_y) { nextPos.y = y; }
        if (_z) { nextPos.z = z; }
        return nextPos;
    }
    #endregion

    #region Event
    private void OnMouseDrag()
    {
        this.gameObject.layer = 2;
        var blockInScreen = Camera.main.WorldToScreenPoint(_block.transform.position);
        var v = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, blockInScreen.z));

        float x = (float)(Math.Floor(v.x / 0.5) * 0.5);
        float y = (float)(Math.Floor(v.y / 0.5) * 0.5);
        float z = (float)(Math.Floor(v.z / 0.5) * 0.5);
        if (y <= 0) { y = _block.Height; }

        _nextPos = _getNextPos(x, y, z);
        _block.transform.position = _nextPos;
    }

    private void OnMouseUp()
    {
        this.gameObject.layer = 0;
    }
    #endregion
}
