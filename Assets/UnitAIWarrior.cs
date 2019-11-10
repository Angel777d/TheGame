using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum WarriorState
{
    Idle = 0,
    FindTarget,
    MovingToTarget,
    Attack,
}

public class UnitAIWarrior : MonoBehaviour
{
    private TargetScript _target;
    private WarriorScript _warrior;
    private GoToTargetScript _goTo;
    private RelationScript _relationScript;

    private WarriorState _state = WarriorState.Idle;


    private void Start()
    {
        _target = GetComponent<TargetScript>();
        _warrior = GetComponent<WarriorScript>();
        _goTo = GetComponent<GoToTargetScript>();
        _goTo = GetComponent<GoToTargetScript>();
        _relationScript = GetComponent<RelationScript>();
    }

    void Update()
    {
        switch (_state)
        {
            case WarriorState.Idle:
                _state = WarriorState.FindTarget;
                break;
            case WarriorState.FindTarget:
                var target = FindEnemy();
                if (target)
                {
                    _target.SetTarget(target.gameObject);
                    _state = WarriorState.MovingToTarget;
                    _goTo.enabled = true;
                }

                break;
            case WarriorState.MovingToTarget:
                if (!_target.HasTarget())
                {
                    _goTo.enabled = false;
                    _state = WarriorState.Idle;
                }

                break;
        }
    }

    GameObject FindEnemy()
    {
        var lst = FindObjectsOfType<RelationScript>().Where(rel => _relationScript.GetRelation(rel) == Relation.Enemy)
            .ToList();

        var pos = transform.position;
        lst.Sort((s1, s2) => Utils.CompareDistance(s1, s2, pos));
        return lst.Count > 0 ? lst[0].gameObject : null;
    }
}