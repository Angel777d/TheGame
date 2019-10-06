using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionsScript : MonoBehaviour
{
    public void StartBuild(GameObject prefab)
    {
        ResetBuilding();
        Instantiate(prefab);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) ResetBuilding();
    }

    private void ResetBuilding()
    {
        foreach (var placeScript in FindObjectsOfType<BuildingPlaceScript>())
        {
            var obj = placeScript.gameObject;
            Destroy(obj);
        }
    }
}