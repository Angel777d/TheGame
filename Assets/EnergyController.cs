using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    private readonly List<EnergyAccumulatorScript> _accumulatorList = new List<EnergyAccumulatorScript>();

    public void RegisterAccumulator(EnergyAccumulatorScript acc)
    {
        _accumulatorList.Add(acc);
    }

    public void UnregisterAccumulator(EnergyAccumulatorScript acc)
    {
        _accumulatorList.Remove(acc);
    }

    public void Charge(float income, Vector3 pos, float distance)
    {
        var filtered = _accumulatorList.Where(acc => Vector3.Distance(acc.transform.position, pos) <= distance)
            .ToList();
        filtered.ToList().Sort((s1, s2) => Utils.CompareDistance(s1, s2, pos));

        foreach (var accumulatorScript in filtered)
        {
            if (Math.Abs(income) < 0.00001f) break;
            income -= accumulatorScript.Charge(income);
        }
    }

    public float Use(float value, GameObject obj)
    {
        var pos = obj.transform.position;
        var filtered = _accumulatorList.Where(acc =>
                Vector3.Distance(acc.transform.position, obj.transform.position) <= acc.UseDistance() &&
                (acc.CanShare() || acc.gameObject == obj))
            .ToList();
        filtered.Sort((s1, s2) => Utils.CompareDistance(s1, s2, pos));
        float result = 0;
        foreach (var accumulatorScript in filtered)
        {
            result += accumulatorScript.Use(value - result);
            if (Math.Abs(value - result) < 0.00001f) break;
        }

        return result;
    }
}