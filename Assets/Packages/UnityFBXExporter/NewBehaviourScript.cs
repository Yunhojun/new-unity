using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityFBXExporter;
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objMeshToExport;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            asd();
        }
    }

    void asd()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "data");
        path = Path.Combine(path, "eeeeee" + ".fbx");

        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        FBXExporter.ExportGameObjToFBX(objMeshToExport, path, false, false);
    }
}
