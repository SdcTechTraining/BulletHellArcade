using UnityEngine;
using System.Collections;
using System;

public class DestroyOnHitTarget : MonoBehaviour, ITarget {
    public void TakeHit(IShot shot)
    {
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
