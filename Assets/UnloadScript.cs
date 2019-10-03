using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnloadScript : MonoBehaviour
{
    [SerializeField] private float unloadSpeed = 2f; //times per sec. 

    private StorageScript[] _storages;
    private ResourceHub _hub;
    private float _dt;
    
    private void OnEnable()
    {
        _dt = 0;
        _storages = GetComponents<StorageScript>();
        _hub = GetComponent<TargetScript>().GetTarget().GetComponent<ResourceHub>();
    }

    private void OnDisable()
    {
        _hub = null;
    }

    void Update()
    {
        if (CanUnload()) ProcessUnload();
    }

    public bool CanUnload()
    {
        return _storages.Any(storage => storage.NotEmpty() && _hub.CanStore(storage.Type));
    }

    private void ProcessUnload()
    {
        _dt += Time.deltaTime;
        var count = (uint) Math.Floor(unloadSpeed * _dt);
        _dt -= count / unloadSpeed;

        foreach (var storage in _storages)
        {
            if (_hub.CanStore(storage.Type) && storage.NotEmpty())
            {
                var requested = storage.Pull(count);
                var accepted = _hub.Push(storage.Type, requested);
                storage.Push(requested - accepted);
            }
        }
    }
}