using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Part : MonoBehaviour
{
    #region Property
    [SerializeField] private float _partHeight;
    [SerializeField] private Coordinate _coodinate;
    [SerializeField] private Material _opaqueMat;
    [SerializeField] private Material _transparentMat;

    public float Height { get { return _partHeight; } }
    public bool IsActive { get { return _isActive; } set { _isActive = value; } }
    public PartMover Mover { get { return _partMover; } }
    public PartRotater Rotater { get { return _partRotater; } }
    public Material PartMaterial { get { return _material; } set { _meshRenderer.material = value; } }

    private bool _isActive;
    private Material _material;
    private MeshRenderer _meshRenderer;
    private PartMover _partMover;
    private PartRotater _partRotater;
    #endregion

    #region Constructor
    private void Awake()
    {
        _isActive = false;

        _meshRenderer = this.GetComponent<MeshRenderer>();
        _partMover = this.GetComponent<PartMover>();
        _partRotater = this.GetComponent<PartRotater>();
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
        ActivePartManager.ResetActivePart();
        Destroy(this.gameObject);
    }

    private void ChangePartMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
    #endregion

    #region Event
    private void OnMouseDown()
    {
        ActivePartManager.SetToActive(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "IgnoreBlockCollision") { ChangePartMaterial(_transparentMat); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "IgnoreBlockCollision") { ChangePartMaterial(_opaqueMat); }
    }
    #endregion
}
