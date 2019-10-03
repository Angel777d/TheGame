using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum BuildingState
{
    Noraml = 0,
    UnderConstruction,
    Abandoned,
    Placing,
}


public class BuildingScript : MonoBehaviour
{
    [SerializeField] private BuildingState state;
    
    void Start()
    {
    }

    void Update()
    {
    }
}