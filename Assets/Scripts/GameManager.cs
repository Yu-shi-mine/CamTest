using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Property
    [SerializeField] ActiveObjectManager _activeObjManager;
    #endregion

    #region Constructor
    private void Start()
    {

    }
    #endregion

    #region Method
    private void Update()
    {
        if (_activeObjManager.ActiveObject != null)
        {
            KickActiveBlockEvent();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S)) { Debug.Log("save"); }
#else
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.S)) { Debug.Log("save"); }
        }
#endif
    }
    #endregion

    #region Event
    private void KickActiveBlockEvent()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { _activeObjManager.ActiveObject.Rotater.RotateRight(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { _activeObjManager.ActiveObject.Rotater.RotateLeft(); }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            _activeObjManager.ActiveObject.Delete();
            Resources.UnloadUnusedAssets();
        }
    }
    #endregion
}
