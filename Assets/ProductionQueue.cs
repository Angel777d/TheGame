using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProductionQueue : MonoBehaviour
{
    [SerializeField] private uint queueSize = 5;
    [SerializeField] private List<GameObject> productionQueue = new List<GameObject>();

    public void AddToQueue(GameObject prefab)
    {
        if (!CanAdd()) return;
        productionQueue.Add(prefab);
    }

    private bool CanAdd()
    {
        return queueSize > productionQueue.Count;
    }

    public GameObject GetCurrent()
    {
        return productionQueue.Count > 0 ? productionQueue[0] : null;
    }

    public void RemoveFromQueue(GameObject prefab)
    {
        Assert.AreEqual(prefab, productionQueue[0]);
        productionQueue.RemoveAt(0);
    }
}