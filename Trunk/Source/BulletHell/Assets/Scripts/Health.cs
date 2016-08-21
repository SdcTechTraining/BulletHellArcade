using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour , IHealth {

    public float HP = 50f;
    public float HitPoints
    {
        get
        {
            return HP;
        }

        set
        {
            var old = HP;
            HP = value;
            if (HP != old)
            {
                foreach(var healthTrigger in GetComponents<IHealthTrigger>())
                {
                    healthTrigger.HealthChanged(old, HP);
                }
            }
        }
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
