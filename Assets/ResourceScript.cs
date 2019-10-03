using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum ResourceType
{
    None = 0,
    Iron,
    Oil,
    Energy,
    Work,
}

public class ResourceScript : MonoBehaviour
{
    private StorageScript _storage;
    [SerializeField] private bool isInfinite = false;

    private void Start()
    {
        _storage = GetComponent<StorageScript>();
    }

    public ResourceType Type
    {
        get => _storage.Type;
    }

    public uint Pull(uint value)
    {
        if (isInfinite) return value;
        return _storage.Pull(value);
    }

    public bool NotEmpty()
    {
        return isInfinite || _storage.NotEmpty();
    }
}