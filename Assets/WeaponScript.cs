using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float range = 3;
    [SerializeField] private float DPS = 1;

    [SerializeField] private GameObject launchPoint;

    private GameObject _target;
    private HitPointsScript _targetHp;

    public void SetTarget(GameObject target)
    {
        _target = target;
        _targetHp = _target ? target.GetComponent<HitPointsScript>() : null;
    }

    void Update()
    {
        if (_target && _targetHp && _targetHp.GetAlive())
            MakeDamage();
    }

    private void MakeDamage()
    {
        var m_pos = launchPoint ? launchPoint.transform.position : transform.position;
        var t_pos = _target.transform.position;
        var distance = Vector3.Distance(m_pos, t_pos);
        if (distance > range) return;

        _targetHp.ApplyDamage(GetDamageValue());
    }

    private float GetDamageValue()
    {
        var dmg = Time.deltaTime * DPS;
        return dmg;
    }
}