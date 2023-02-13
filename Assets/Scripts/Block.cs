using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Property
    [SerializeField] private float _blockHeight;
    [SerializeField] private GameObject _axisObj;

    public float Height { get { return _height; } }
    public GameObject Axis { get { return _axis; } }
    public bool IsSelected { get { return _isSelected; } set { _isSelected = value; } }

    private float _height;
    private GameObject _axis;
    private bool _isSelected;
    #endregion

    #region Constructor
    private void Awake()
    {
        _height = _blockHeight;
        _axis = _axisObj;
        _isSelected = false;
    }
    #endregion

    #region Method
    private void Update()
    {
        _axis.SetActive(_isSelected);
    }
    #endregion

    #region Event
    private void OnMouseDown()
    {
        _isSelected = ObjectManager.SetActiveObject(this.gameObject);
    }
    #endregion
}
