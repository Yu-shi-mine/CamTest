using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartIDManager : MonoBehaviour
{
    #region Property
    private static Dictionary<int, GameObject> _partsDict;
    #endregion

    #region Constructor
    private void Start()
    {
        _partsDict = new Dictionary<int, GameObject>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            _partsDict.Add(i, this.transform.GetChild(i).gameObject);
        }
        this.gameObject.SetActive(false);
    }
    #endregion

    #region Method
    public static GameObject GetGameObject(int ID)
    {
        return _partsDict[ID];
    }
    #endregion
}
