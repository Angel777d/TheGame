using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Assertions;


class ProductionProcess
{
    public GameObject product;
    public ProductionCostScript cost;
    public float energy;

    public bool Active
    {
        get => product;
    }

    public bool Ready
    {
        get => Active && energy >= cost.energy;
    }

    public GameObject Clear()
    {
        var result = product;
        product = null;
        cost = null;
        energy = 0;
        return result;
    }
}

public class BuildingProductionScript : MonoBehaviour
{
    [SerializeField] private ProductionQueue queue;
    [SerializeField] private float productionPower = 10; //energy units per second

    private readonly ProductionProcess _product = new ProductionProcess();
    private EnergyController _energy;

    private void Start()
    {
        _energy = FindObjectOfType<EnergyController>();
    }

    private void Update()
    {
        if (!_product.Active)
        {
            StartProduction(queue.GetCurrent());
        }

        if (_product.Active)
        {
            ProcessProduction();
        }
    }

    private void StartProduction(GameObject product)
    {
        if (product)
        {
            _product.product = product;
            _product.cost = product.GetComponent<ProductionCostScript>();
        }
    }

    private void ProcessProduction()
    {
        var power = _energy.Use(productionPower * Time.deltaTime, gameObject);
        _product.energy += power;
        if (_product.Ready)
        {
            FinishProduction();
        }
    }

    private void FinishProduction()
    {
        var obj = _product.Clear();
        queue.RemoveFromQueue(obj);
        Instantiate(obj).transform.position = GetComponent<PointScript>().GetPosition();
    }
}