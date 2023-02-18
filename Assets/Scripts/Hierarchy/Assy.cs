using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assy : MonoBehaviour
{
    #region Property
    public string Name { get { return _name; } set { _name = value; } }
    public List<SubAssy> SubAssys { get { return _subAssys; } }

    private string _name;
    private List<SubAssy> _subAssys = new List<SubAssy>();
    #endregion

    #region Constructor
    private void Awake()
    {
        _name = "NewAssembly";
        _subAssys.Add(new SubAssy("NewSubAssy"));
    }
    #endregion

    #region Method
    public static void Add(SubAssy subassy)
    {

    }

    public static void Remove()
    {

    }
    #endregion

    #region Event

    #endregion
}
