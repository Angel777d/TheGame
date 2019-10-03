using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    [SerializeField] private float collectSpeed = .5f; //items per sec

    private StorageScript _storage;
    private ResourceScript _resource;
    private float _dt;

    private void OnEnable()
    {
        _dt = 0;
        _resource = GetComponent<TargetScript>().GetTarget().GetComponent<ResourceScript>();
        _storage = GetComponents<StorageScript>().Where(script => _resource.Type == script.Type).ToList()[0];
    }

    private void OnDisable()
    {
        _storage = null;
        _resource = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanCollect()) ProcessCollecting();
    }

    public bool CanCollect()
    {
        return _storage.GetFreeSpace() > 0 && _resource.NotEmpty();
    }

    void ProcessCollecting()
    {
        _dt += Time.deltaTime;

        var count = (uint) Math.Floor(collectSpeed * _dt);
        _dt -= count / collectSpeed;

        count = Math.Min(count, _storage.GetFreeSpace());
        _storage.Push(_resource.Pull(count));
    }
}