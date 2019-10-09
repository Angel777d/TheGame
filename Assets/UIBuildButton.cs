using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    private BuildingProductionScript _scr;
    private int _index;

    public void SetItem(BuildingProductionScript scr, int index)
    {
        _scr = scr;
        _index = index;
        UpdateDescription(scr.productionList[index]);
        button.onClick.AddListener(HandleClick);
    }

    private void UpdateDescription(GameObject obj)
    {
        var desc = obj.GetComponent<DescriptionScript>();
        text.text = desc.Name;
    }

    public void HandleClick()
    {
        _scr.AddToQueue(_index);
    }
}