using UnityEngine;

public class PlaceResource : MonoBehaviour
{
    private PlaceBuildingScript _placer;
    [SerializeField] private ResourceType type;

    private void Start()
    {
        _placer = GetComponent<PlaceBuildingScript>();
    }


    private void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log("OnTriggerEnter");
        var res = otherObject.GetComponent<ResourceScript>();
        if (res && res.Type == type)
        {
            _placer.SetAllowed(true);
            _placer.SetTarget(res.gameObject);
        }
    }

    private void OnTriggerExit(Collider otherObject)
    {
        _placer.SetAllowed(false);
        _placer.SetTarget(null);
    }
}