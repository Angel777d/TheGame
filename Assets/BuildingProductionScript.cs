using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BuildingProductionScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> productionList = new List<GameObject>();
    [SerializeField] public List<uint> productionTimeList = new List<uint>();

    public void AddToQueue(int index)
    {
        if (!CanAdd()) return;
        Debug.Assert(index < productionList.Count, "There is no such product in list");
        productionQueue.Add(index);
    }

    [SerializeField] private List<int> productionQueue = new List<int>();
    [SerializeField] private uint queueSize = 5;

    [SerializeField] private Vector3 outPosition = Vector3.forward * 2;

    private float _dt = 0;


    private bool CanAdd()
    {
        return queueSize > productionQueue.Count;
    }

    private void Update()
    {
        if (productionQueue.Count == 0)
        {
            _dt = 0;
            return;
        }

        ProcessProduction();
    }

    private void ProcessProduction()
    {
        _dt += Time.deltaTime;
        var index = productionQueue[0];
        var productionTime = productionTimeList[index];

        if (_dt > productionTime)
        {
            FinishProduction(index);
        }
    }

    private Vector3 GetOutPosition()
    {
        return transform.position + outPosition;
    }

    private void FinishProduction(int index)
    {
        _dt = 0;
        productionQueue.RemoveAt(0);

        var obj = productionList[index];
        var instance = Instantiate(obj);

        instance.transform.position = GetOutPosition();
    }
}