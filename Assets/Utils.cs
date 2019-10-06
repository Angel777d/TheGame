//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;


enum GameObjectLayer
{
    Ground = 8,
}

public class Utils
{
    public static GameObject GetObjectUnderMouse(string tag)
    {
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);
        if (!hit) return null;

        GameObject obj;
        return (obj = hitInfo.transform.gameObject).CompareTag(tag) ? obj : null;
    }

    public static Vector3 GetGroundPosition()
    {
        int layerMask = 1 << LayerMask.NameToLayer(GameObjectLayer.Ground.ToString());

        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100, layerMask);
        if (!hit) return Vector3.zero;

        return hitInfo.point;
    }

    public static StorageScript GetStorageByType(GameObject obj, ResourceType type)
    {
        var lst = obj.GetComponents<StorageScript>().Where(script => script.Type == type).ToList();
        return lst.Count > 0 ? lst[0] : null;
    }
}