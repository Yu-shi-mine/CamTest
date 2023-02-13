using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    #region Property
    [HideInInspector]
    public bool IsSelected;

    [SerializeField]
    public BlockProperty BlockProperty;

    [SerializeField]
    private GameObject Axis;

    //マウスの始点 
    private Vector3 _startMousePos;

    //オブジェクトの移動前position
    Vector3 _presentPos;
    BoxCollider _boxCol;

    //オブジェクトの移動先position
    Vector3 _nextPos;

    //オブジェクトのy方向移動量
    private float _distY;

    float _xMax, _xMin, _zMax, _zMin;
    #endregion

    #region Constructor
    private void Start()
    {
        _xMax = -1000.0f;
        _xMin = -1000.0f;
        _zMax = -1000.0f;
        _zMin = -1000.0f;
        IsSelected = false;
        _boxCol = GetComponent<BoxCollider>();
        _nextPos = Vector3.zero;
    }
    #endregion

    #region Method
    private void Update()
    {
        Axis.SetActive(IsSelected);
        if (IsSelected)
        {
            ObjRotateKeyControl();
        }
    }
    #endregion

    #region Event
    private void OnMouseDown()
    {
        IsSelected = ObjectManager.SetActiveObject(this.gameObject);
        _startMousePos = Input.mousePosition;
        _presentPos = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsSelected)
        {
            _distY = other.transform.GetComponent<BlockProperty>().Height * 2;
            _xMax = other.transform.position.x + 0.5f;
            _xMin = other.transform.position.x - 0.5f;
            _zMax = other.transform.position.z + 0.5f;
            _zMin = other.transform.position.z - 0.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsSelected)
        {
            //_distY = 0.0f;
        }
    }

    private void OnMouseDrag()
    {
        this.gameObject.layer = 2;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            float x = (float)(Math.Truncate(hit.point.x / 0.5) * 0.5);
            float z = (float)(Math.Truncate(hit.point.z / 0.5) * 0.5);
            _nextPos.x = x;
            _nextPos.z = z;
            _nextPos.y = GetYPosition(x, z);

            transform.position = _nextPos;
            //transform.position = new Vector3(hit.point.x, BlockProperty.Height + _distY, hit.point.z);
        }
    }

    private float GetYPosition(float x, float z)
    {
        float posY = 0.0f;

        Debug.Log(String.Format("xMin = {0}, xMax = {1}, zMin = {2}, zMax = {3}", _xMin, _xMax, _zMin, _zMax));
        Debug.Log(String.Format("xM = {0}, z = {1}", x, z));
        if (_xMax < 0)
        {
            posY = BlockProperty.Height;
        }
        else if((_xMin <= x) && (x <= _xMax) && (_zMin <= z) && (z <= _zMax))
        {
            Debug.Log("in");
            posY = BlockProperty.Height + _distY;
        }
        else
        {
            posY = BlockProperty.Height;
            _xMax = -1000.0f;
            _xMin = -1000.0f;
            _zMax = -1000.0f;
            _zMin = -1000.0f;
        }

        return posY;
    }

    private void OnMouseUp()
    {
        this.gameObject.layer = 0;
    }

    private void ObjRotateKeyControl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { this.transform.RotateAround(this.transform.position, Vector3.up, 90.0f); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { this.transform.RotateAround(this.transform.position, Vector3.up, -90.0f); }
    }
    #endregion
}
