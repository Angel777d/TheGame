using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAccumulatorScript : MonoBehaviour
{
    [SerializeField] private float capacity = 100;
    [SerializeField] private float value = 100;
    [SerializeField] private float chargeSpeed = 5; //units per second
    
    public float Charge(float potentialIncome)
    {
        var maxIncome = Mathf.Min(Time.deltaTime * chargeSpeed, potentialIncome);
        maxIncome = Mathf.Min(maxIncome, capacity - value);
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