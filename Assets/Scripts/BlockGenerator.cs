using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    #region Property
    [SerializeField] private GameObject _blockParent;
    [SerializeField] private Block _block;

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
        GameObject block = GameObject.Instantiate(_block.gameObject, _originPosition, _oruiginRotation, _blockParent.transform);
    }
    #endregion

    #region Event

    #endregion
}
