using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PartGenerator : MonoBehaviour
{
    #region Property
    private ScreenUtil _screenUtil;
    private Vector3 _generatePosition;
    private Quaternion _originRotation = Quaternion.Euler(0f, 0f, 0f);
    private float _positionInterval = 0.5f;
    #endregion

    #region Constructor
    private void Start()
    {
        _screenUtil = new ScreenUtil();
    }
    #endregion

    #region Method
    public void Generaete(Part part)
    {
        _generatePosition = GetGeneratePosition(part);
        GameObject o = Instantiate(part.gameObject, _generatePosition, _originRotation, GameManager.PartsParent.transform);
        ActivePartManager.SetToActive(o.GetComponent<Part>());
    }

    private Vector3 GetGeneratePosition(Part part)
    {
        Vector3 v = _screenUtil.ScreenCentorToWorldPosition();

        v.x = RoundHalfUp(v.x, _positionInterval);
        v.y = RoundHalfUp(v.y, _positionInterval);
        v.z = RoundHalfUp(v.z, _positionInterval);
        if (v.y <= 0) { v.y += part.Height; }

        return v;
    }
    private float RoundHalfUp(float value, float interval)
    {
        return (float)(Math.Floor(value / interval) * interval);
    }
    #endregion

    #region Event

    #endregion
}
