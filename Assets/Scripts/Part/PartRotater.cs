using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRotater : MonoBehaviour
{
    #region Property
    
    #endregion

    #region Constructor
    private void Awake()
    {
        
    }
    #endregion

    #region Method
    public void RotateRight()
    {
        this.transform.RotateAround(this.transform.position, Vector3.up, 90.0f);
    }

    public void RotateLeft()
    {
        this.transform.RotateAround(this.transform.position, Vector3.up, -90.0f);
    }
    #endregion

    #region Event

    #endregion
}
