using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class WarriorScript : MonoBehaviour
{
    [SerializeField] private List<WeaponScript> weapons = new List<WeaponScript>();

    private TargetScript _target;

    void Start()
    {
        _target = GetComponent<TargetScript>();
        _target.EvTargetChanged.AddListener(OnTargetChanged);
    }

    private void OnTargetChanged()
    {
        var newTarget = _target.GetTarget();
        foreach (var weapon in weapons)
        {
            weapon.SetTarget(newTarget);
        }
    }
}