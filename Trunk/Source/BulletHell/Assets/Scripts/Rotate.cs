using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public Vector3 RotationSpeed = Vector3.one;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(RotationSpeed * Time.deltaTime);
	}
}
