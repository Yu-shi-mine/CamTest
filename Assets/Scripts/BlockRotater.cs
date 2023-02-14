using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotater : MonoBehaviour
{
    #region Property
    private Block _block;
    #endregion

    #region Constructor
    private void Awake()
    {
        _block = this.transform.GetComponent<Block>();
    }
    #endregion

    #region Method
    private void Update()
    {
        if (_block.IsSelected)
        {
            ObjRotateKeyControl();
        }
    }
    #endregion

    #region Event
    private void ObjRotateKeyControl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { this.transform.RotateAround(this.transform.position, Vector3.up, 90.0f); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { this.transform.RotateAround(this.transform.position, Vector3.up, -90.0f); }
    }
    #endregion
}
