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
    public static GameObject GetObjectUnderMouse(string[] tags)
    {
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);
        if (!hit) return null;

        GameObject obj = hitInfo.transform.gameObject;

        return tags.Any(tag => obj.CompareTag(tag)) ? obj : null;
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

    public static int CompareDistance(Component c1, Component c2, Vector3 pos)
    {
        return CompareDistance(c1.gameObject, c2.gameObject, pos);
    }

    public static int CompareDistance(GameObject c1, GameObject c2, Vector3 pos)
    {
        var p1 = c1.transform.position;
        var p2 = c2.transform.position;

        return Vector3.Distance(p1, pos) < Vector3.Distance(p2, pos) ? -1 : 1;
    }
}