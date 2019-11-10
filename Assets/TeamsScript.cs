using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
class TeamDescription
{
    [SerializeField] public int teamId = 0;
    [SerializeField] public int[] enemies;
    [SerializeField] public int[] allies;
}

public class TeamsScript : MonoBehaviour
{
    [SerializeField] private int playerTeamId = 0;
    [SerializeField] private TeamDescription[] teams;
    
    public Relation GetRelation(RelationScript current, RelationScript other)
    {
        if (current.TeamId == other.TeamId)
        {
            return Relation.Own;
        }

        var team = teams.First(description => description.teamId == current.TeamId);
        if (team.enemies.Contains(other.TeamId))
        {
            return Relation.Enemy;
        }

        if (team.allies.Contains(other.TeamId))
        {
            return Relation.Ally;
        }

        return Relation.Neutral;
    }
}