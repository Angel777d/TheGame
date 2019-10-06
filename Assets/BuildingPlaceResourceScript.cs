using UnityEngine;

public class BuildingPlaceResourceScript : MonoBehaviour, IPlaceBuildingCondition
{
    private bool _isAllowed;
    private GameObject _target;

    [SerializeField] private ResourceType type = ResourceType.None;

    private void Start()
    {
        GetComponent<BuildingPlaceScript>().AddCondition(this);
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log("OnTriggerEnter");

        var res = otherObject.GetComponent<ResourceScript>();
        _isAllowed = res && res.Type == type;
        if (_isAllowed)
        {
            _target = res.gameObject;
        }
    }

    private void OnTriggerExit(Collider otherObject)
    {
        _isAllowed = false;
        _target = null;
    }

    public bool IsAllowed()
    {
        return _isAllowed;
    }

    public Vector3 GetTargetPosition()
    {
        return _target.transform.position;
    }

    public bool HasTarget()
    {
        return _target;
    }
}