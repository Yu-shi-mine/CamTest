using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    #region Property
    private Coordinate _coordinate;
    private Part _part;
    #endregion

    #region Constructor
    private void Awake()
    {
        _coordinate = this.transform.GetComponentInParent<Coordinate>();
        _part = _coordinate.ParentObject;
    }
    #endregion

    #region Method

    #endregion

    #region Event
    private void OnMouseDrag()
    {
        this.gameObject.layer = 2;
        _part.Mover.Move(this.transform.up);
    }

    private void OnMouseUp()
    {
        this.gameObject.layer = 0;
    }
    #endregion
}
