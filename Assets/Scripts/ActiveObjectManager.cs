using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectManager : MonoBehaviour
{
    #region Property
    public Object ActiveObject { get { return _activeObject; } }

    private static Object _activeObject;
    #endregion

    #region Constructor
    private void Start()
    {
        
    }
    #endregion

    #region Method
    public static void SetToActive(Object block)
    {
        if (_activeObject != null)
        {
            _activeObject.DeactivateAxis();
            _activeObject.IsActive = false;
        }
        block.IsActive = true;
        block.ActivateAxis();
        _activeObject = block;
    }

    public static void ResetActiveObject()
    {
        if (_activeObject != null)
        {
            _activeObject.DeactivateAxis();
            _activeObject.IsActive = false;
            _activeObject = null;
        }
    }
    #endregion

    #region Event

    #endregion
}
