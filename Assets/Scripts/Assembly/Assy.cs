using System.Collections;
using System.Collections.Generic;

using UnityEngine;


[System.Serializable]
public class Assy
{
    #region Property
    public List<PartInfo> PartInfoList;
    #endregion

    #region Constructor
    public Assy(List<GameObject> parts)
    {
        PartInfoList = new List<PartInfo>();
        foreach (GameObject p in parts) { PartInfoList.Add(new PartInfo(p)); }
    }
    #endregion
}


[System.Serializable]
public class PartInfo
{
    #region Property
    public string Name;
    public Vector3 Position;
    public Quaternion Rotation;
    public int PartID;
    public int MatrialID;
    #endregion

    #region Constructor
    public PartInfo(GameObject o)
    {
        Name = o.name;
        Position = o.transform.position;
        Rotation = o.transform.rotation;
        var p = o.GetComponent<Part>();
        PartID = p.ID;
        MatrialID = p.MaterialID;
    }
    #endregion
}

[System.Serializable]
public class Objects
{
    #region Property
    public GameObject _gameObject;
    #endregion

    #region Constructor
    public Objects(GameObject parent)
    {
        _gameObject = parent;
    }
    #endregion
}