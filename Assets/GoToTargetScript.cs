using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToTargetScript : MonoBehaviour
{
    private TargetScript _target;
    private NavMeshAgent _agent;

    void Update()
    {
        _agent.destination = _target.GetTargetPosition();
    }

    public bool IsNear(float distance)
    {
        var t_pos = _target.GetTargetPosition();
        var m_pos = transform.position;
        return distance > Vector3.Distance(t_pos, m_pos);
    }

    private void OnEnable()
    {
        _target = GetComponent<TargetScript>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.isStopped = false;
    }

    private void OnDisable()
    {
//        _agent.isStopped = true;
        _target = null;
        _agent = null;
    }
}