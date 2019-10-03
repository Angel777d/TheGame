using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

public class StorageScript : MonoBehaviour
{
    [SerializeField] private ResourceType type = ResourceType.Oil;
    [SerializeField] private uint capacity = 100;
    [SerializeField] private uint value = 0;

    public ResourceType Type => type;

    public bool NotEmpty()
    {
        return value > 0;
    }

    public uint GetFreeSpace()
    {
        return capacity - value;
    }

    public uint Push(uint size)
    {
        var freeSpace = capacity - value;
        var result = Math.Min(size, freeSpace);
        value += result;
        return result;
    }

    public uint Pull(uint size)
    {
        var result = Math.Min(size, value);
        value -= result;
        return result;
    }
}