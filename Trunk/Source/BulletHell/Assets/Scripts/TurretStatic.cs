using UnityEngine;
using System.Collections;
using System;

public class TurretStatic : MonoBehaviour {

    /// <summary>
    /// What Object to Rotate
    /// </summary>
    public GameObject RotationPart;

    /// <summary>
    /// How many times should the rotation pause to shoot during a full rotation.
    /// </summary>
    public int RotationDivision = 4;

    /// <summary>
    /// The speed that the turret rotates
    /// </summary>
    public float RotationSpeed = 1;

    /// <summary>
    /// Time to wait before shooting again.
    /// </summary>
    public float ShootPause = 0.25f;

    /// <summary>
    /// Once it stops, it will fire this many times before 
    /// </summary>
    public int ShotsPerDirection = 4;

    public TriggerShot Shooter;

    private int shotsFiredThisDirection = 0;

    private float rotationDistance = 0;

    private bool shooting = false;

    private float timeSinceLastShot = 0;

    private float fullRotation = 0;
	void Start () {
        fullRotation = 360;
	}
	

	void Update () {
        Shoot();
        Rotate();
	}

    private void Rotate()
    {
        if (shooting) return;

        var rotate = RotationSpeed * Time.deltaTime;
        RotationPart.transform.Rotate(Vector3.up * rotate);
        rotationDistance += rotate;

        if (rotationDistance > fullRotation / RotationDivision)
        {
            var counterRotation = (fullRotation / RotationDivision) - rotationDistance;
            RotationPart.transform.Rotate(Vector3.up * counterRotation);
            rotationDistance = 0;
            shooting = true;
            timeSinceLastShot = ShootPause;
        }
    }

    private void Shoot()
    {
        if (!shooting) return;
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot > ShootPause)
        {
            timeSinceLastShot = 0;
            if (Shooter != null) Shooter.Shoot = true;
            Debug.Log("Shooting");
            shotsFiredThisDirection++;
            if (shotsFiredThisDirection >= ShotsPerDirection)
            {
                shotsFiredThisDirection = 0;
                shooting = false;
            }
        }
    }
}
