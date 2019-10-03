using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MyGameState
{
    None = 0,
    Selecting,
    Placing,
}

public class GameStateScript : MonoBehaviour
{
    private MyGameState _state;
}