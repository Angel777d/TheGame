using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionScript : MonoBehaviour
{
    [SerializeField] public Material image;

    [SerializeField] private string objectName = "Some name";
    [SerializeField] private string description = "Some description";


    public string Name
    {
        get => MakeLocalized(objectName);
    }

    public string Description
    {
        get => MakeLocalized(description);
    }


    private string MakeLocalized(string inString)
    {
        return inString;
    }
}