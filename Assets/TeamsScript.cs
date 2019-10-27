using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamsScript : MonoBehaviour
{
    [SerializeField] private int myTeamId = 0;
    [SerializeField] private int[] enemies = {1, 3};
    [SerializeField] private int[] allies = {2};

    public Relation GetRelation(int teamId)
    {
        if (teamId == myTeamId)
        {
            return Relation.Own;
        }

        if (enemies.Contains(teamId))
        {
            return Relation.Enemy;
        }

        if (allies.Contains(teamId))
        {
            return Relation.Ally;
        }

        return Relation.Neutral;
    }
}