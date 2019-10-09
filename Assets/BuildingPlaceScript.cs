using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingPlaceScript : MonoBehaviour
{
    private BuildingScript _building;
    private List<IPlaceBuildingCondition> _conditions;

    private void Start()
    {
        _building = GetComponent<BuildingScript>();
        _building.SetState(BuildingState.Placing);

        _conditions = new List<IPlaceBuildingCondition>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void AddCondition(IPlaceBuildingCondition condition)
    {
        _conditions.Add(condition);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetAllowed())
        {
            PlaceBuilding();
        }
        else
        {
            UpdatePosition();
        }
    }

    private bool GetAllowed()
    {
        var allowed = true;
        foreach (var condition in _conditions)
        {
            allowed = allowed && condition.IsAllowed();
        }

        return allowed;
    }

    private void UpdatePosition()
    {
        var m_pos = Utils.GetGroundPosition();
        foreach (var condition in _conditions)
        {
            if (condition.HasTarget())
            {
                var t_pos = condition.GetTargetPosition();
                if (Vector3.Distance(m_pos, t_pos) < 1)
                {
                    m_pos = t_pos;
                    break;
                }
            }
        }

        transform.position = m_pos;
    }

    private void PlaceBuilding()
    {
        //clear all place conditions
        foreach (var placeBuildingCondition in _conditions)
        {
            Destroy(placeBuildingCondition as Component);
        }

        //clear conditions collection
        _conditions.Clear();
        _conditions = null;

        //remove Rigidbody added at start
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Destroy(rb);

        _building.SetState(BuildingState.Active);

        //remove this script from gameObject
        Destroy(this);
    }
}