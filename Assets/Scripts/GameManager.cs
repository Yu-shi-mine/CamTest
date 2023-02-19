using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region Property
    [SerializeField] ActivePartManager _activePartManager;
    [SerializeField] PartGenerator _partGenerator;
    [SerializeField] GameObject _assembly;
    private static GameObject _partsParent;
    private static bool _isSaved;
    private PartGenerator _generator;

    public static GameObject PartsParent { get { return _partsParent; } }
    public static bool IsSaved { get { return _isSaved; } set { _isSaved = value; } }
    #endregion

    #region Constructor
    private void Start()
    {
        _partsParent = _assembly;
        _generator = _partGenerator;
        _isSaved = false;
    }
    #endregion

    #region Method
    private void Update()
    {
        if (_activePartManager.ActivePart != null) { KickActiveBlockEvent(); }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S)) { bool saved = FileIO.Save(_partsParent); }
        if (Input.GetKeyDown(KeyCode.O)) { bool loaded = FileIO.Load(_partsParent); }
        //if (Input.GetKeyDown(KeyCode.N)) { SceneManager.LoadScene("Main"); }
#else
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.S))
        {
            bool saved = FileIO.Save(_partsParent);
        }
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.O))
        {
            bool loaded = FileIO.Load(_partsParent);
        }
        //if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.N))
        //{
        //    SceneManager.LoadScene("Main");
        //}
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

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.D))
        {
            _generator.Generaete(_activePartManager.ActivePart);
        }
    }
    #endregion
}
