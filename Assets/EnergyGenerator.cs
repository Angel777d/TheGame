using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class EnergyGenerator : MonoBehaviour
{
    [SerializeField] private float power = 1; //energy unit per second
    [SerializeField] private float chargeDistance = 5;

    private EnergyController _controller;
    
    private void Start()
    {
        _controller = FindObjectOfType<EnergyController>();
    }

    private void Update()
    {
        var value = Time.deltaTime * power;
        _controller.Charge(value, transform.position, chargeDistance);
    }
}