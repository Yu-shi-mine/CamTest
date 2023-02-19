using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Part : MonoBehaviour
{
    #region Property
    [SerializeField] private float _partHeight;
    [SerializeField] private GameObject _boss;
    [SerializeField] private Coordinate _coodinate;
    [SerializeField] private Material _transparentMat;
    [SerializeField] private int _iD;
    [SerializeField] private int _materialID;

    public float Height { get { return _partHeight; } set { _partHeight = value; } }
    public int ID { get { return _partID; } set { _partID = value; } }
    public int MaterialID { get { return _matID; } set { _matID = value; } }
    public bool IsActive { get { return _isActive; } set { _isActive = value; } }
    public PartMover Mover { get { return _partMover; } }
    public PartRotater Rotater { get { return _partRotater; } }
    public Material PartMaterial { get { return _material; } set { ChangePartMaterial(value); } }

    private bool _isActive;
    private int _partID;
    private int _matID;
    private Material _material;
    private List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();
    private PartMover _partMover;
    private PartRotater _partRotater;
    #endregion

    #region Constructor
    private void Awake()
    {
        StartCoroutine("_Awake");
        
    }

    private IEnumerator _Awake()
    {
        _isActive = false;
        _partID = _iD;

        _meshRenderers.Add(this.GetComponent<MeshRenderer>());
        foreach (Transform t in _boss.transform) { _meshRenderers.Add(t.GetComponent<MeshRenderer>()); }

        yield return StartCoroutine("WaitForMatID");
        ChangePartMaterial(MaterialIDManager.GetMaterial(_matID));

        _partMover = this.GetComponent<PartMover>();
        _partRotater = this.GetComponent<PartRotater>();
    }
    #endregion

    #region Method
    private IEnumerable WaitForMatID()
    {
        yield return new WaitUntil(() => MaterialIDManager.IsReady);
    }

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
        foreach (MeshRenderer renderer in _meshRenderers) { renderer.material = material; }
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
        if (other.gameObject.tag != "IgnoreBlockCollision") { ChangePartMaterial(MaterialIDManager.GetMaterial(_matID)); }
    }
    #endregion
}
