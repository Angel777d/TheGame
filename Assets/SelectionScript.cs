using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    public const string SELCTABLE_TAG = "Selectable";

    [SerializeField] private GameObject currentTarget = null;

//    void Start()
//    {
//    }

    void Update()
    {
        if (ProcessReset()) return;
        if (ProcessSelect()) return;
    }

    public void SetTarget(GameObject target)
    {
        currentTarget = target;
    }

    bool ProcessReset()
    {
        if (!Input.GetMouseButtonDown(1)) return false;
        SetTarget(null);
        return true;
    }

    bool ProcessSelect()
    {
        if (currentTarget) return false;
        if (!Input.GetMouseButtonDown(0)) return false;
        SetTarget(Utils.GetObjectUnderMouse(SELCTABLE_TAG));
        return true;
    }

}