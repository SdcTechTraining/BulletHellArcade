using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    public static Player Current { get; set; }

    public float Speed = 5f;
    public float LookSpeed = 3f;
	public float JumpForce = 10f;
    public Transform Head;

    private new Rigidbody rigidbody = null;
	private new CapsuleCollider collider = null;
	private bool crouching = false;

    void Start()
    {
        Current = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();
		collider = GetComponent<CapsuleCollider> ();
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
		
    void Update()
    {
        Look();
        Move();
        Escape();
        Jump();
		Crouch ();
    }

	private void Crouch()
	{
		if (!crouching && Input.GetKeyDown (KeyCode.LeftControl)) {
			crouching = true;
			collider.height *= 0.5f;
			return;
		}
		if (crouching && Input.GetKeyUp (KeyCode.LeftControl)) {
			crouching = false;
			collider.height *= 2;

		}
	}

    private void Jump()
    {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (1)) {
			
			var grounded = Physics.Raycast (transform.position, Vector3.down, collider.bounds.extents.y + 0.1f);
			if (grounded) {
				rigidbody.AddRelativeForce (JumpForce * Vector3.up);
			}
		}
    }

    private void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Look()
    {
        var mouseX = Input.GetAxis("Mouse X") * LookSpeed;
        var mouseY = Input.GetAxis("Mouse Y") * LookSpeed;
        var mouseDelta = new Vector3(-mouseY, 0f, 0f); 
        Head.Rotate(mouseDelta, Space.Self);

        mouseDelta = new Vector3(0f, mouseX, 0f);
        transform.Rotate(mouseDelta, Space.Self);
    }

    private void Move()
    {
        var adjustment = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) adjustment += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) adjustment += Vector3.back;
        if (Input.GetKey(KeyCode.D)) adjustment += Vector3.right;
        if (Input.GetKey(KeyCode.A)) adjustment += Vector3.left;
        transform.Translate(adjustment * Speed * Time.deltaTime);
    }
}
