using UnityEngine;
using System.Collections;
using System;

public class SmallShot : MonoBehaviour, IShot {
    public float Damage { get; set; }

    public float ShotLife { get; set; }

    public float PresetDamage = 10;

    public float PresetLife = 10;


    // Use this for initialization
    void Start () {
        ShotLife = PresetLife;
        Damage = PresetDamage;
	}
	
	// Update is called once per frame
	void Update () {
        ShotLife -= Time.deltaTime;
        if (ShotLife < 0) Destroy(gameObject);
	}

    void OnCollisionEnter(Collision hit)
    {
        Debug.Log("hit " + hit.gameObject.name);
        foreach (var hitter in hit.gameObject.GetComponents<ITarget>())
        {
            hitter.TakeHit(this);
        }

        Destroy(gameObject);
    }
}
