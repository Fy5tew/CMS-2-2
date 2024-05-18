using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovementRB : MonoBehaviour {
	public float movementSpeed = 1;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newVelocity = Vector3.zero;

		if (Input.GetKey(KeyCode.I)) {
			newVelocity.z += movementSpeed;
		}
        if (Input.GetKey(KeyCode.J)) {
			newVelocity.x -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.K)) {
			newVelocity.z -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.L)) {
			newVelocity.x += movementSpeed;
        }
		newVelocity.y += rb.velocity.y;

		rb.velocity = newVelocity;
	}
}
