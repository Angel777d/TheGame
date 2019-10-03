using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Relation
{
    Neutral = 0,
    Ally,
    Enemy,
    Own
}

public class RelationScript : MonoBehaviour
{
    [SerializeField] private Relation relation;

    [SerializeField] private int teamId = 0;
}