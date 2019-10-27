using UnityEngine;
using UnityEngine.Events;

public class HitPointsScript : MonoBehaviour
{
    [SerializeField] private float maxHP = 5;
    [SerializeField] private float currentHP = 5;

    public UnityEvent EvKilled = new UnityEvent();

    public float GetHP()
    {
        return currentHP;
    }

    public float GetPercent()
    {
        return currentHP / maxHP;
    }

    public bool GetAlive()
    {
        return currentHP > 0;
    }

    public void ApplyDamage(float damage)
    {
        var isAlive = currentHP > 0;
        currentHP -= damage;
        if (isAlive && currentHP <= 0)
        {
            currentHP = 0;
            OnKilled();
        }
    }

    private void OnKilled()
    {
        EvKilled.Invoke();
        Destroy(gameObject);
    }
}