using UnityEngine;
using System.Collections;
using System;
[RequireComponent(typeof(IHealth))]
public class ExplodeOnNoHealth : MonoBehaviour, IHealthTrigger
{
    public GameObject ExplosionPrefab;

    void IHealthTrigger.HealthChanged(float oldHealth, float newHealth)
    {
        if (newHealth < 0)
        {
            var explosion = GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
