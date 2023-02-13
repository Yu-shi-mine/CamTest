using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperty : MonoBehaviour
{
    #region Property
    [SerializeField] private float Blockheight;

    public float Height { get { return _height; } }
    private float _height;
    #endregion

    #region Constructor
    private void Start()
    {
        _height = Blockheight;
        Debug.Log(Height);
    }
    #endregion
}
