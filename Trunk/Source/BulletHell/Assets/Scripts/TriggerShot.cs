using UnityEngine;
using System.Collections;

public class TriggerShot : MonoBehaviour, IGun
{

    public float StartingForce = 100f;
    public float Force { get; set; }

    public GameObject StartingShotPrefab;
    public GameObject Prefab { get; set; }

    public bool Shoot { get; set; }

    // Use this for initialization
    void Start()
    {
        Force = StartingForce;
        Prefab = StartingShotPrefab;
        Shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Shoot)
        {
            if (Prefab != null)
            {
                Shoot = false;
                var go = (GameObject)GameObject.Instantiate(Prefab, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(Force * Vector3.forward);
            }
        }
    }
}