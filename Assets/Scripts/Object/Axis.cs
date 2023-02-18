using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    #region Property
    private Coordinate _coordinate;
    private Object _object;
    #endregion

    #region Constructor
    private void Awake()
    {
        _coordinate = this.transform.GetComponentInParent<Coordinate>();
        _object = _coordinate.ParentObject;
    }
    #endregion

    #region Method

    #endregion

    #region Event
    private void OnMouseDrag()
    {
        this.gameObject.layer = 2;
        _object.Mover.Move(this.transform.up);
    }

    private void OnMouseUp()
    {
        this.gameObject.layer = 0;
    }
    #endregion
}
