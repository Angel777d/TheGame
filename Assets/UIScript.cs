using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private SelectionScript selection;
    [SerializeField] private UITargetScript target;
    [SerializeField] private UIGeneralScript general;


    private GameObject _target;

    private void Start()
    {
        general.gameObject.SetActive(true);
        target.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (_target == selection.CurrentTarget) return;
        _target = selection.CurrentTarget;
        OnTargetChanged(_target);
    }

    private void OnTargetChanged(GameObject target)
    {
        var isTarget = target;
        var isGeneral = !isTarget;

        general.gameObject.SetActive(isGeneral);
        this.target.gameObject.SetActive(isTarget);

        this.target.UpdateBuilding(target);
    }
}