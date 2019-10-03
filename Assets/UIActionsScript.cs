using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionsScript : MonoBehaviour
{
    public void StartBuild(GameObject prefab)
    {
        GameObject.Instantiate(prefab);
    }
}