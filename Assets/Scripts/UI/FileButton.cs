using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class FileButton : MonoBehaviour
{
    #region Property
    [SerializeField] private GameObject _subButtons;
    #endregion

    #region Constructor
    private void Start()
    {
        _subButtons.SetActive(false);
    }
    #endregion

    #region Method
    public void OpenSubButtons()
    {
        _subButtons.SetActive(true);
    }

    public void OnClickSaveButtons()
    {
        FileIO.Save(GameManager.PartsParent);
    }

    public void OnClickLoadButtons()
    {
        FileIO.Load(GameManager.PartsParent);
    }
    #endregion

    #region Event

    #endregion
}
