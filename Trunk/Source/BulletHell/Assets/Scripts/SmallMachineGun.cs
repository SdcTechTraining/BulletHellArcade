using UnityEngine;
using System.Collections;

public class SmallMachineGun : MonoBehaviour, IGun {


    public float StartingForce = 100f;

    public float TimeBetweenShots = 0.25f;
    public float Force { get; set; }

    public GameObject StartingShotPrefab;
    public GameObject Prefab { get; set; }

    private bool shoot = false;

    private float timeSinceLastShot = 0;

    // Use this for initialization
    void Start()
    {
        Force = StartingForce;
        Prefab = StartingShotPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot < TimeBetweenShots) return;
        timeSinceLastShot = 0;
        if (Input.GetMouseButton(0))
        {
            if (Prefab != null)
            {
                var go = (GameObject)GameObject.Instantiate(Prefab, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(Force * Vector3.forward);
            }
        }
    }
}
