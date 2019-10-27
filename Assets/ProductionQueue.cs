using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProductionQueue : MonoBehaviour
{
    [SerializeField] private uint queueSize = 5;
    private readonly List<GameObject> _productionQueue = new List<GameObject>();

    public void AddToQueue(GameObject prefab)
    {
        if (!CanAdd()) return;
        _productionQueue.Add(prefab);
    }

    private bool CanAdd()
    {
        return queueSize > _productionQueue.Count;
    }

    public GameObject GetCurrent()
    {
        return _productionQueue.Count > 0 ? _productionQueue[0] : null;
    }

    public void RemoveFromQueue(GameObject prefab)
    {
        Assert.AreEqual(prefab, _productionQueue[0]);
        _productionQueue.RemoveAt(0);
    }
}