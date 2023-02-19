using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SFB;


public class FileIO : MonoBehaviour
{
    #region Property
    private static ExtensionFilter[] _extentionFilter = new[] { new ExtensionFilter("Json", "json") };
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
        if ((saveName == null) || (saveName == "")) { return false; }

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
        return StandaloneFileBrowser.SaveFilePanel("Save File", "", "New Assembly", "json");
    }

    private static void WriteJson(string json, string saveName)
    {
        StreamWriter writer = new StreamWriter(saveName, false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public static bool Load(GameObject parent)
    {
        string loadName = GetFileName();
        if ((loadName == null) || (loadName == "")) { return false; }

        StreamReader reader;
        reader = new StreamReader(loadName);
        string datastr = reader.ReadToEnd();
        reader.Close();

        foreach (PartInfo p in JsonUtility.FromJson<Assy>(datastr).PartInfoList)
        {
            GameObject o = Instantiate(PartIDManager.GetGameObject(p.PartID));
            o.transform.SetParent(parent.transform);
            o.name = p.Name;
            o.transform.position = p.Position;
            o.transform.rotation = p.Rotation;
            o.GetComponent<MeshRenderer>().material = MaterialIDManager.GetMaterial(p.MatrialID);
        }

        return true;
    }

    private static string GetFileName()
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", _extentionFilter, false);

        if ((paths.Length != 0) && (paths[0] != null)) { return paths[0]; }
        else { return null; }
    }
    #endregion

    #region Event

    #endregion
}
