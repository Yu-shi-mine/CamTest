using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using UnityEngine;


public class FileIO : MonoBehaviour
{
    #region Property
    #endregion

    #region Constructor
    private void Start()
    {
        
    }
    #endregion

    #region Method
    public static bool Save(GameObject parent)
    {
        string saveName = GetSaveName();
        if (saveName == null) { return false; }

        var parts = GetChildObject(parent);
        Assy assy = new Assy(parts);
        WriteJson(JsonUtility.ToJson(assy), saveName);

        return true;
    }

    private static List<GameObject> GetChildObject(GameObject parent)
    {
        List<GameObject> parts = new List<GameObject>();
        foreach (Transform t in parent.transform) { parts.Add(t.gameObject); }
        return parts;
    }

    private static string GetSaveName()
    {
        var dlg = new SaveFileDialog();
        dlg.Filter = "json(*.json)|*.json|All files(*.*)|*.*";
        dlg.CheckFileExists = false;
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            return dlg.FileName;
        }
        else if (dlg.ShowDialog() == DialogResult.Cancel)
        {
            return null;
        }
        else
        {
            return null;
        }
    }

    private static void WriteJson(string json, string saveName)
    {
        StreamWriter writer = new StreamWriter(saveName, false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public static bool Load()
    {
        string loadName = GetFileName();
        if (loadName == null) { return false; }

        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(loadName);
        datastr = reader.ReadToEnd();
        reader.Close();

        JsonUtility.FromJson<Assy>(datastr);

        return true;
    }

    private static string GetFileName()
    {
        var dlg = new OpenFileDialog();
        dlg.Filter = "json(*.json)|*.json|All files(*.*)|*.*";
        dlg.CheckFileExists = false;
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            return dlg.FileName;
        }
        else if (dlg.ShowDialog() == DialogResult.Cancel)
        {
            return null;
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region Event

    #endregion
}
