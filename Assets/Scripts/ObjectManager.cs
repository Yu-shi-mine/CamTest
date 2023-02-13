using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Property
    public static GameObject ActiveObject;
    #endregion

    #region Constructor
    void Start()
    {
        
    }
    #endregion

    #region Method
    void Update()
    {

    }

    public static bool SetActiveObject(GameObject gameObject)
    {
        if (ActiveObject != null)
        {
            ActiveObject.GetComponent<ObjectController>().IsSelected = false;
        }
        ActiveObject = gameObject;
        return true;
    }

    #endregion

    #region Event

    #endregion
}
