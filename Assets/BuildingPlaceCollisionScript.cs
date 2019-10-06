using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceCollisionScript : MonoBehaviour, IPlaceBuildingCondition
{
    private readonly List<GameObject> _collisions = new List<GameObject>();

    [SerializeField] private ResourceType type = ResourceType.None;

    private void Start()
    {
        GetComponent<BuildingPlaceScript>().AddCondition(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGroudLayer(collision)) return;
        _collisions.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isGroudLayer(collision)) return;
        _collisions.Remove(collision.gameObject);
    }

    public bool IsAllowed()
    {
        return _collisions.Count == 0;
    }

    public Vector3 GetTargetPosition()
    {
        return Vector3.zero;
    }

    public bool HasTarget()
    {
        return false;
    }

    private bool isGroudLayer(Collision collision)
    {
        var gLayer = LayerMask.NameToLayer(GameObjectLayer.Ground.ToString());
        return collision.gameObject.layer == gLayer;
    }
}