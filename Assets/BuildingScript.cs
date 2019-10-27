using System;
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
    [SerializeField] private BuildingState state = BuildingState.Placing;
    [SerializeField] public ResourceType resBinding = ResourceType.None;

    public bool IsActive()
    {
        return state == BuildingState.Active;
    }

    public void SetState(BuildingState value)
    {
        state = value;
    }
}