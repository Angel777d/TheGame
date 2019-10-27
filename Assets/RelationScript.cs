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
    [SerializeField] private int teamId = 0;

    private TeamsScript _teams;

    private void Start()
    {
        _teams = FindObjectOfType<TeamsScript>();
    }

    public Relation GetRelation()
    {
        return _teams.GetRelation(teamId);
    }
}