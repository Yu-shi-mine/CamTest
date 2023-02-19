using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class MaterialIDManager : MonoBehaviour
{
    #region Property
    [SerializeField] GameObject _palette;
    private static Dictionary<int, Material> _materialDict;
    private static bool _ready;

    public static bool IsReady { get { return _ready; } }
    #endregion

    #region Constructor
    private void Awake()
    {
        _ready = false;

        _materialDict = new Dictionary<int, Material>();
        for (int i = 0; i < _palette.transform.childCount; i++)
        {
            _materialDict.Add(i, _palette.transform.GetChild(i).GetComponent<Image>().material);
        }
        _ready = true;
    }
    #endregion

    #region Method
    public static Material GetMaterial(int ID)
    {
        return _materialDict[ID];
    }
    #endregion

    #region Event

    #endregion
}
