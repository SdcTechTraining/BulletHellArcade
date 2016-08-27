using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	public GameObject Player { get; set; }
	public bool IsGrounded { get; set; } 
	
    public void OnCollisionEnter(Collision col)
    {
		if (col.gameObject == Player)
			return;

		IsGrounded = true;
    }

    public void OnCollisionExit(Collision col)
    {
		if (col.gameObject == Player)
			return;

		IsGrounded = false;
    }
}
