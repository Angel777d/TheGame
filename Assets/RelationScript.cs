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
    Own,
    Unknown
}

public class RelationScript : MonoBehaviour
{
    [SerializeField] private int teamId = 0;

    private TeamsScript _teams;

    private void Start()
    {
        _teams = FindObjectOfType<TeamsScript>();
    }

    public int TeamId => teamId;

    public Relation GetRelation(RelationScript other)
    {
        // Find can be called before start
        return _teams ? _teams.GetRelation(this, other) : Relation.Unknown;
    }
}