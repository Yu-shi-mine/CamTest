using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : MonoBehaviour
{
    #region Property
    public Object ParentObject  { get { return _object; } }
    private Object _object;
    #endregion

    #region Constructor
    private void Awake()
    {
        _object = this.transform.GetComponentInParent<Object>();
    }
    #endregion

    #region Method

    #endregion

    #region Event

    #endregion
}
