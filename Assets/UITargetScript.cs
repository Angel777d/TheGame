using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UITargetScript : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image image;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject prodPlaceholder;

    List<GameObject> _buttons = new List<GameObject>();

    private GameObject _target;

    public void UpdateBuilding(GameObject value)
    {
        _target = value;
        if (_target)
        {
            UpdateDescription(_target);
            UpdateProduction(_target);
        }
    }

    private void UpdateDescription(GameObject target)
    {
        var desc = target.GetComponent<DescriptionScript>();
        text.text = desc.Name;
        image.material = desc.image;
    }

    private void UpdateProduction(GameObject target)
    {
        foreach (var button in _buttons)
        {
            Destroy(button);
        }

        _buttons.Clear();

        var scr = target.GetComponent<ProductionListScript>();
        if (!scr) return;
        int xPos = 0;
        foreach (var product in scr.productionList)
        {
            var button = Instantiate(buttonPrefab, prodPlaceholder.transform);
            _buttons.Add(button);
            var bscr = button.GetComponent<UIBuildButton>();
            bscr.SetItem(target.GetComponent<ProductionQueue>(), product);
            bscr.transform.position = bscr.transform.position + new Vector3(xPos, 0, 0);
            xPos += 150;
        }
    }

//
//
//    function removebutton(gameObject)
//    {
//        Destroy(gameObject);
//        var text1 = new ("text", CanvasRenderer, Text);
//        text1.text = "Button removed";
//    }
}