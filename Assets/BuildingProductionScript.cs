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
    [SerializeField] private Vector3 outPosition = Vector3.forward * 2;
    [SerializeField] private ProductionQueue queue;
    [SerializeField] private float productionPower = 1; //energy units per second

    private ProductionProcess _product = new ProductionProcess();

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

    private Vector3 GetOutPosition()
    {
        return transform.position + outPosition;
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
        _product.energy += productionPower * Time.deltaTime;
        if (_product.Ready)
        {
            FinishProduction();
        }
    }

    private void FinishProduction()
    {
        var obj = _product.Clear();
        queue.RemoveFromQueue(obj);
        Instantiate(obj).transform.position = GetOutPosition();
    }
}