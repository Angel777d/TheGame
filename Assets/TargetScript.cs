using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.PlayerLoop;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Vector3 targetPosition = Vector3.zero;

    private bool _hasTarget;
    public UnityEvent EvTargetChanged = new UnityEvent();

    private void Update()
    {
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (!_hasTarget || targetObject) return;
        _hasTarget = false;
        EvTargetChanged.Invoke();
    }

    public void SetTarget(GameObject obj)
    {
        if (targetObject == obj) return;
        _hasTarget = obj;
        targetObject = obj;
        EvTargetChanged.Invoke();
    }

    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
    }

    public bool HasTarget()
    {
        return _hasTarget;
    }

    public GameObject GetTarget()
    {
        return targetObject;
    }

    public Vector3 GetTargetPosition()
    {
        return targetObject ? targetObject.transform.position : targetPosition;
    }
}