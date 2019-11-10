using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const string AxisHor = "Horizontal";
    private const string AxisVer = "Vertical";
    private const string AxisDist = "Mouse ScrollWheel";

    [SerializeField] private float move_sens = .5f;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera)
        { 
            var pos = camera.transform.position;
            pos.x += Input.GetAxis(AxisHor) * move_sens;
            pos.z += Input.GetAxis(AxisVer) * move_sens;
            
            pos.y += Input.GetAxis(AxisDist) * move_sens*10;
            camera.transform.position = pos;
        }
    }
}