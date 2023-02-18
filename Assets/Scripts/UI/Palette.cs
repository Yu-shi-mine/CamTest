using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    #region Property
    
    #endregion

    #region Constructor
    private void Start()
    {
        
    }
    #endregion

    #region Method
    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
    #endregion

    #region Event

    #endregion
}
