using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Vector3 targetPosition = Vector3.zero;

    public void SetTarget(GameObject obj)
    {
        targetObject = obj;
    }

    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
    }

    public bool HasTarget()
    {
        return targetObject;
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