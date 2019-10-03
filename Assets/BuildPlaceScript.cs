using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlaceScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnDestroy()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
    }


}