using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceHub : MonoBehaviour
{
    private StorageScript[] _storList;

    // Start is called before the first frame update
    void Start()
    {
        _storList = GetComponents<StorageScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool CanStore(ResourceType type)
    {
        return GetStores(type).Count > 0;
    }

    public uint Push(ResourceType type, uint value)
    {
        return GetStores(type)[0].Push(value);
    }

    public uint Pull(ResourceType type, uint value)
    {
        return GetStores(type)[0].Pull(value);
    }

    private List<StorageScript> GetStores(ResourceType type)
    {
        return _storList.Where(s => s.Type == type && s.GetFreeSpace() > 0).ToList();
    }
}