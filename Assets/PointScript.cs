using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PointScript : MonoBehaviour
{
    [SerializeField] private Vector3 point = Vector3.forward * 2;

    public void SetPosition(Vector3 pos)
    {
        point = pos - transform.position;
    }

    public Vector3 GetPosition()
    {
        return transform.position + point;
    }
}