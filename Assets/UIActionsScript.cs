using UnityEngine;

public class UIActionsScript : MonoBehaviour
{
    public void StartBuild(GameObject prefab)
    {
        ResetBuilding();
        var obj = Instantiate(prefab);
        var building = obj.GetComponent<BuildingScript>();
        obj.AddComponent<BuildingPlaceScript>();
        obj.AddComponent<BuildingPlaceCollisionScript>();

        if (building.resBinding != ResourceType.None)
        {
            var resScript = obj.AddComponent<BuildingPlaceResourceScript>();
            resScript.ResType = building.resBinding;
        }
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