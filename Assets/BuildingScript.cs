using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum BuildingState
{
    Placing = 0,
    UnderConstruction,
    Active,
    Abandoned,
}


public class BuildingScript : MonoBehaviour
{
    private BuildingState _state = BuildingState.Placing;


    public bool IsActive()
    {
        return _state == BuildingState.Active;
    }

    public void SetState(BuildingState value)
    {
        _state = value;
    }

    void Start()
    {
    }

    void Update()
    {
    }
}