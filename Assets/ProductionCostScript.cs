using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ResourceEntry
{
    public ResourceType type;
    public float value;
}

public class ProductionCostScript : MonoBehaviour
{
    [SerializeField] public float energy = 10;
    [SerializeField] public List<ResourceEntry> price = new List<ResourceEntry>();
}