using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceBuildingScript : MonoBehaviour
{
    private bool _allowed = true;
    private GameObject _target;


    public void SetTarget(GameObject value)
    {
        _target = value;
    }

    public void SetAllowed(bool value)
    {
        _allowed = value;
    }

    void Start()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        var isDown = Input.GetMouseButtonDown(0);
        if (isDown && _allowed)
        {
            PlaceBuilding();
            Destroy(this);
        }
        else
        {
            var m_pos = Utils.GetGroundPosition();
            if (_target)
            {
                var t_pos = _target.transform.position;
                transform.position = Vector3.Distance(m_pos, t_pos) < 1 ? t_pos : m_pos;
            }
            else
            {
                transform.position = m_pos; 
            }
        }
    }

    private void PlaceBuilding()
    {
    }
}