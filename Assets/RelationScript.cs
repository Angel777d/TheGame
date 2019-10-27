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
        var rel = _teams.GetRelation(teamId);
    }

    public Relation GetRelation()
    {
        // Find can be called before start
        return _teams ? _teams.GetRelation(teamId) : Relation.Unknown;
    }
}