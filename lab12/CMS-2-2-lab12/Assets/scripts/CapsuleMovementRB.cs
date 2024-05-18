using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovementRB : MonoBehaviour {
    public float keyboardMoveSpeed = 1;
    public float mouseMoveSpeed = 1;
    public float jumpPower = 0;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newVelocity = Vector3.zero;

        newVelocity += new Vector3(
            keyboardMoveSpeed * Input.GetAxis("Horizontal"),
            0,
            keyboardMoveSpeed * Input.GetAxis("Vertical")
        );
        newVelocity += new Vector3(
            mouseMoveSpeed * Input.GetAxis("Mouse X"),
            0,
            mouseMoveSpeed * Input.GetAxis("Mouse Y")
        );
        if (Input.GetKeyDown(KeyCode.Space)) {
            newVelocity.y += jumpPower;
        }
        newVelocity.y += rb.velocity.y;

        rb.velocity = newVelocity;
    }
}
