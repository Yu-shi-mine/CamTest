using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    #region Property
    [SerializeField] private ActivePartManager _activePartManager;

    private Material _material;
    #endregion

    #region Constructor
    private void Start()
    {
        _material = this.GetComponent<Image>().material;
    }
    #endregion

    #region Method
    public void SetAcivePartColor()
    {
        _activePartManager.ActivePart.PartMaterial = _material;
    }
    #endregion

    #region Event

    #endregion
}
