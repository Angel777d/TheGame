using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    private readonly string[] _tags = {Tags.Building.ToString(), Tags.Unit.ToString()};
    [SerializeField] private GameObject currentTarget = null;


    public GameObject CurrentTarget
    {
        get => currentTarget;
        set => currentTarget = value;
    }

    void Update()
    {
        if (ProcessReset()) return;
        if (ProcessSelect()) return;
    }

    bool ProcessReset()
    {
        if (!Input.GetMouseButtonDown(1)) return false;
        CurrentTarget = null;
        return true;
    }

    bool ProcessSelect()
    {
        if (currentTarget) return false;
        if (!Input.GetMouseButtonDown(0)) return false;

        CurrentTarget = Utils.GetObjectUnderMouse(_tags);
        return true;
    }
}