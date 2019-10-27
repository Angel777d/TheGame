using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    private ProductionQueue _scr;
    private GameObject _prefab;

    public void SetItem(ProductionQueue scr, GameObject prefab)
    {
        _scr = scr;
        _prefab = prefab;
        UpdateDescription(prefab);
        button.onClick.AddListener(HandleClick);
    }

    private void UpdateDescription(GameObject obj)
    {
        var desc = obj.GetComponent<DescriptionScript>();
        text.text = desc.Name;
    }

    private void HandleClick()
    {
        _scr.AddToQueue(_prefab);
    }
}