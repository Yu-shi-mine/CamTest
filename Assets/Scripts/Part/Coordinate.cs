using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : MonoBehaviour
{
    #region Property
    public Part ParentObject  { get { return _part; } }

    private Part _part;
    #endregion

    #region Constructor
    private void Awake()
    {
        _part = this.transform.GetComponentInParent<Part>();
    }
    #endregion

    #region Method

    #endregion

    #region Event

    #endregion
}
