using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtil
{
    #region Property

    #endregion

    #region Constructor
    public ScreenUtil()
    {

    }
    #endregion

    #region Method
    public Vector3 ScreenCentorToWorldPosition()
    {
        float x = Screen.width / 2f;
        float y = Screen.height / 2f;
        float z = 0;

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) { z = Camera.main.WorldToScreenPoint(hit.point).z; }

        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, z)); ;
    }
    #endregion

    #region Event

    #endregion
}
