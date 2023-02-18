using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region Property
    [SerializeField] ActivePartManager _activePartManager;
    [SerializeField] GameObject _partsParent;
    #endregion

    #region Constructor
    private void Start()
    {

    }
    #endregion

    #region Method
    private void Update()
    {
        if (_activePartManager.ActivePart != null) { KickActiveBlockEvent(); }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S)) { bool saved = FileIO.Save(_partsParent); }
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
        if (Input.GetKeyDown(KeyCode.RightArrow))   { _activePartManager.ActivePart.Rotater.RotateRight(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow))    { _activePartManager.ActivePart.Rotater.RotateLeft(); }
        if (Input.GetKeyDown(KeyCode.Escape))       { ActivePartManager.ResetActivePart(); }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            _activePartManager.ActivePart.Delete();
            Resources.UnloadUnusedAssets();
        }
    }
    #endregion
}
