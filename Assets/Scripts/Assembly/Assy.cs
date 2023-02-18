using System.Collections;
using System.Collections.Generic;

using UnityEngine;


[System.Serializable]
public class Assy
{
    #region Property
    public List<PartInfo> _parts;
    #endregion

    #region Constructor
    public Assy(List<GameObject> parts)
    {
        _parts = new List<PartInfo>();
        foreach (GameObject p in parts) { _parts.Add(new PartInfo(p)); }
    }
    #endregion
}


[System.Serializable]
public class PartInfo
{
    #region Property
    public string _name;
    public Vector3 _position;
    public Quaternion _rotation;
    public Material _material;
    #endregion

    #region Constructor
    public PartInfo(GameObject part)
    {
        _name = part.name;
        _position = part.transform.position;
        _rotation = part.transform.rotation;
        _material = part.GetComponent<MeshRenderer>().material;
    }
    #endregion
}