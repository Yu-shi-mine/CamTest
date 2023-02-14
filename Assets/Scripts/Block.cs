using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Property
    [SerializeField] private float _blockHeight;
    [SerializeField] private GameObject _axisObj;
    [SerializeField] private GameObject _boss;
    [SerializeField] private Material _opaqueMat;
    [SerializeField] private Material _transparentMat;

    public float Height { get { return _height; } }
    public GameObject Axis { get { return _axis; } }
    public bool IsSelected { get { return _isSelected; } set { _isSelected = value; } }

    private float _height;
    private GameObject _axis;
    private bool _isSelected;
    private List<MeshRenderer> _meshRenderers;
    #endregion

    #region Constructor
    private void Awake()
    {
        _height = _blockHeight;
        _axis = _axisObj;
        _isSelected = false;

        _meshRenderers = new List<MeshRenderer>();
        _meshRenderers.Add(this.GetComponent<MeshRenderer>());
        foreach (Transform t in _boss.transform)
        {
            _meshRenderers.Add(t.GetComponent<MeshRenderer>());
        }
    }
    #endregion

    #region Method
    private void Update()
    {
        _axis.SetActive(_isSelected);
    }

    private void ChangeBlockMaterial(Material material)
    {
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material = material;
        }
    }
    #endregion

    #region Event
    private void OnMouseDown()
    {
        _isSelected = ObjectManager.SetActiveObject(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "IgnoreBlockCollision")
        {

            ChangeBlockMaterial(_transparentMat);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "IgnoreBlockCollision")
        {
            ChangeBlockMaterial(_opaqueMat);
        }
    }
    #endregion
}
