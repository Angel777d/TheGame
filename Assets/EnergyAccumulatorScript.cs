using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAccumulatorScript : MonoBehaviour
{
    [SerializeField] private float capacity = 100;
    [SerializeField] private float value = 100;

    [SerializeField] private bool share = false;
    [SerializeField] private float useDistance = 5;

    private EnergyController _controller;

    private void Awake()
    {
        _controller = FindObjectOfType<EnergyController>();
        _controller.RegisterAccumulator(this);
    }

    private void OnDestroy()
    {
        _controller.UnregisterAccumulator(this);
        _controller = null;
    }

    public bool CanShare()
    {
        return share;
    }
    
    public float UseDistance()
    {
        return useDistance;
    }

    public float Charge(float potentialIncome)
    {
        var maxIncome = Mathf.Min(potentialIncome, capacity - value);
        value += maxIncome;
        return maxIncome;
    }

    public float Use(float potentialOutcome)
    {
        var result = Mathf.Min(value, potentialOutcome);
        value -= result;
        return result;
    }
}