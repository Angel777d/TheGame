using System.Collections.Generic;
using System.Linq;
using UnityEngine;


class ProductionProcess
{
    private GameObject _product;
    private ProductionCostScript _cost;
    private float _energy;
    private readonly Dictionary<ResourceType, float> _have = new Dictionary<ResourceType, float>();

    public bool Active => _product;
    public bool Ready => Active && _energy >= _cost.energy;

    public void Set(GameObject obj)
    {
        Clear();
        _product = obj;
        _cost = obj.GetComponent<ProductionCostScript>();
        foreach (var resourceEntry in _cost.price)
        {
            _have[resourceEntry.type] = 0;
        }
    }

    public void AddEnergy(float value)
    {
        _energy += value;
    }

    public void AddResource(ResourceType type, float value)
    {
        _have[type] += value;
    }

    public ResourceType[] GetResources()
    {
        return _have.Keys.ToArray();
    }

    public GameObject Get()
    {
        return _product;
    }

    public void Clear()
    {
        _have.Clear();
        _product = null;
        _cost = null;
        _energy = 0;
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
            _product.Set(product);
        }
    }

    private void ProcessProduction()
    {
        var power = _energy.Use(productionPower * Time.deltaTime, gameObject);
        _product.AddEnergy(power);
        if (_product.Ready)
        {
            FinishProduction();
        }
    }

    private void FinishProduction()
    {
        var obj = _product.Get();
        _product.Clear();
        queue.RemoveFromQueue(obj);
        Instantiate(obj).transform.position = GetComponent<PointScript>().GetPosition();
    }
}