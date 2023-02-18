using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartAddButton : MonoBehaviour
{
    #region Property
    [SerializeField] private Part _part;
    [SerializeField] private PartGenerator _partGenerator;
    #endregion

    #region Constructor
    private void Start()
    {
        
    }
    #endregion

    #region Method
    public void CreateObject()
    {
        _partGenerator.Generaete(_part);
    }
    #endregion

    #region Event

    #endregion
}
