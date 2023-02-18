using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ActivePartManager : MonoBehaviour
{
    #region Property
    [SerializeField] private Palette palette;

    public Part ActivePart { get { return _activePart; } }

    private static Part _activePart;
    private static Palette _palette;
    #endregion

    #region Constructor
    private void Start()
    {
        _palette = palette;
        _palette.Deactivate();
    }
    #endregion

    #region Method
    public static void SetToActive(Part part)
    {
        if (_activePart != null)
        {
            _activePart.DeactivateAxis();
            _activePart.IsActive = false;
        }

        part.IsActive = true;
        part.ActivateAxis();
        _activePart = part;

        _palette.Activate();
    }

    public static void ResetActivePart()
    {
        if (_activePart != null)
        {
            _activePart.DeactivateAxis();
            _activePart.IsActive = false;
            _activePart = null;

            _palette.Deactivate();
        }
    }
    #endregion

    #region Event

    #endregion
}
