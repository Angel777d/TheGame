﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


enum CollectorState
{
    Idle = 0,
    FindResource,
    MovingToResource,
    CollectingResource,
    FindHub,
    MovingToHub,
    UnloadResources
}

public class CollectUnitAI : MonoBehaviour
{
    private TargetScript _target;
    private GoToTargetScript _goTo;
    private CollectScript _collect;
    private UnloadScript _unload;

    [SerializeField] private ResourceType targetType = ResourceType.Oil;
    [SerializeField] private float collectDistance = 1.5f;
    [SerializeField] private float unloadDistance = 1.5f;


    private CollectorState _state = CollectorState.Idle;

    void Start()
    {
        _target = GetComponent<TargetScript>();
        _goTo = GetComponent<GoToTargetScript>();
        _collect = GetComponent<CollectScript>();
        _unload = GetComponent<UnloadScript>();
    }

    void Update()
    {
        switch (_state)
        {
            case CollectorState.Idle:
                _state = CollectorState.FindResource;
                break;
            case CollectorState.FindResource:
                var target = FindResource(targetType);
                if (target)
                {
                    _target.SetTarget(target.gameObject);
                    _state = CollectorState.MovingToResource;
                    _goTo.enabled = true;
                }

                break;
            case CollectorState.MovingToResource:
                if (_goTo.IsNear(collectDistance))
                {
                    _goTo.enabled = false;
                    _state = CollectorState.CollectingResource;
                    _collect.enabled = true;
                }

                break;
            case CollectorState.CollectingResource:
                if (!_collect.CanCollect())
                {
                    _collect.enabled = false;
                    _state = CollectorState.FindHub;
                }

                break;
            case CollectorState.FindHub:
                var hub = FindStorage(targetType);
                if (hub)
                {
                    _target.SetTarget(hub.gameObject);
                    _state = CollectorState.MovingToHub;
                    _goTo.enabled = true;
                }

                break;
            case CollectorState.MovingToHub:
                if (_goTo.IsNear(unloadDistance))
                {
                    _goTo.enabled = false;
                    _state = CollectorState.UnloadResources;
                    _unload.enabled = true;
                }

                break;
            case CollectorState.UnloadResources:
                if (!_unload.CanUnload())
                {
                    _unload.enabled = false;
                    _state = CollectorState.Idle;
                }

                break;
        }
    }

    ResourceScript FindResource(ResourceType type)
    {
        var lst = FindObjectsOfType<ResourceScript>().Where(res => res.NotEmpty() && res.Type == type).ToList();

        var pos = transform.position;
        lst.Sort((s1, s2) => CompareDisance(s1, s2, pos));
        return lst.Count > 0 ? lst[0] : null;
    }

    ResourceHub FindStorage(ResourceType type)
    {
        var lst = FindObjectsOfType<ResourceHub>().Where(hub => hub.CanStore(type)).ToList();

        var pos = transform.position;
        lst.Sort((s1, s2) => CompareDisance(s1, s2, pos));
        return lst.Count > 0 ? lst[0] : null;
    }

    int CompareDisance(Component c1, Component c2, Vector3 pos)
    {
        var p1 = c1.gameObject.transform.position;
        var p2 = c2.gameObject.transform.position;

        return Vector3.Distance(p1, pos) < Vector3.Distance(p2, pos) ? -1 : 1;
    }
}