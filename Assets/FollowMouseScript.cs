using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    private void Start()
    {
        enabled = false;
    }

    void Update()
    {
        transform.position = Utils.GetGroundPosition();
    }
}