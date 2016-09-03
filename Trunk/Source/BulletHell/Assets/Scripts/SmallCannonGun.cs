using UnityEngine;
using System.Collections;
using System;

public class SmallCannonGun
    : MonoBehaviour, IGun {

    public float StartingForce = 100f;
    public float Force { get; set; }

    public GameObject StartingShotPrefab;
    public GameObject Prefab { get; set; }

    // Use this for initialization
    void Start () {
        Force = StartingForce;
        Prefab = StartingShotPrefab;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Prefab != null)
            {
                var go = (GameObject)GameObject.Instantiate(Prefab, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(Force * Vector3.forward);
            }
        }
    }
}
