using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HierarchyManager : MonoBehaviour
{
    #region Prpperty
    [SerializeField] GameObject _root;
    [SerializeField] GameObject _UIroot;

    int _assyCount;
    #endregion

    #region Constructor
    private void Start()
    {
        _assyCount = 0;
    }
    #endregion

    #region Method
    public void AddAssembly()
    {
        GameObject subassy = new GameObject();
        subassy.name = "assy_" + _assyCount.ToString();
        subassy.transform.SetParent(_root.transform);

        GameObject subassyUI = new GameObject();
        subassyUI.name = "assy_" + _assyCount.ToString();
        subassyUI.AddComponent<CanvasRenderer>();
        subassyUI.AddComponent<Text>();
        subassyUI.GetComponent<Text>().text = subassyUI.name;
        subassyUI.GetComponent<Text>().font = new Font("Arial");
        subassyUI.GetComponent<Text>().color = Color.black;
        subassyUI.transform.SetParent(_UIroot.transform, false);
    }

    public void AddComponent()
    {

    }
    #endregion

    #region Event

    #endregion
    
}
