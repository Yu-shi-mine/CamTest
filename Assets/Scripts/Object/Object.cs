using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    #region Property
    [SerializeField] private float _objectHeight;
    [SerializeField] private Coordinate _coodinate;
    [SerializeField] private Material _opaqueMat;
    [SerializeField] private Material _transparentMat;

    public float Height { get { return _height; } }
    public bool IsActive { get { return _isActive; } set { _isActive = value; } }
    public ObjectMover Mover { get { return _objectMover; } }
    public ObjectRotater Rotater { get { return _objectRotater; } }

    private float _height;
    private bool _isActive;
    private MeshRenderer _meshRenderer;
    private ObjectMover _objectMover;
    private ObjectRotater _objectRotater;
    #endregion

    #region Constructor
    private void Awake()
    {
        _height = _objectHeight;
        _isActive = false;

        _meshRenderer = this.GetComponent<MeshRenderer>();
        _objectMover = this.GetComponent<ObjectMover>();
        _objectRotater = this.GetComponent<ObjectRotater>();
    }
    #endregion

    #region Method
    public void ActivateAxis()
    {
        _coodinate.gameObject.SetActive(true);
    }

    public void DeactivateAxis()
    {
        _coodinate.gameObject.SetActive(false);
    }

    public void Delete()
    {
        ActiveObjectManager.ResetActiveObject();
        Destroy(this.gameObject);
    }

    private void ChangeBlockMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
    #endregion

    #region Event
    private void OnMouseDown()
    {
        ActiveObjectManager.SetToActive(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "IgnoreBlockCollision") { ChangeBlockMaterial(_transparentMat); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "IgnoreBlockCollision") { ChangeBlockMaterial(_opaqueMat); }
    }
    #endregion
}
