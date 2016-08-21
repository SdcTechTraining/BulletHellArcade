using UnityEngine;
using System.Collections;

public class TakeDamageTarget : MonoBehaviour, ITarget {

    private IHealth health;

    public void TakeHit(IShot shot)
    {
        Debug.Log(name + " takes a hit");
        if (health != null)
        {
            Debug.Log("And has health");
            health.HitPoints -= shot.Damage;
        }
    }


    // Use this for initialization
    void Start()
    {
        health = GetComponent<IHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
