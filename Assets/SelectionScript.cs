using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectionScript : MonoBehaviour
{
    public readonly UnityEvent EvSelected = new UnityEvent();

    private readonly string[] _tags = {Tags.Building.ToString(), Tags.Unit.ToString()};
    [SerializeField] private GameObject currentTarget = null;

    public GameObject CurrentTarget
    {
        get => currentTarget;
    }

    void Update()
    {
        if (ProcessReset()) return;
        if (ProcessSelect()) return;
    }

    bool ProcessReset()
    {
        if (!Input.GetMouseButtonDown(1)) return false;
        SetTarget(null);

        return true;
    }

    bool ProcessSelect()
    {
        if (!Input.GetMouseButtonDown(0)) return false;
        var target = Utils.GetObjectUnderMouse(_tags);
        if (target)
            SetTarget(target);
        return true;
    }

    public void SetTarget(GameObject newTarget)
    {
        if (currentTarget == newTarget) return;
        currentTarget = newTarget;
        EvSelected.Invoke();
    }
}