using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    #region Property
    [SerializeField] private GameObject _objectParent;
    [SerializeField] private Object _object;

    private Vector3 _originPosition = new Vector3(5.5f, 0.5f, 5.5f);
    private Quaternion _oruiginRotation = Quaternion.Euler(0f, 0f, 0f);
    #endregion

    #region Constructor
    private void Start()
    {
        
    }
    #endregion

    #region Method
    public void AddNewBlock()
    {
        GameObject o = GameObject.Instantiate(_object.gameObject, _originPosition, _oruiginRotation, _objectParent.transform);
    }
    #endregion

    #region Event

    #endregion
}
