using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
	public GameObject bash;
	public GameObject dulo;

	public float korpusMoveSpeed = 1.0f;
	public float korpusRotateSpeed = 1.0f;
	public float bashSpeed = 1.0f;
	public float duloSpeed = 1.0f;

	AudioSource movementSound;

	// Use this for initialization
	void Start () {
		movementSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(
			0f,
			0f,
            korpusMoveSpeed * Input.GetAxis("Vertical")
        );
		transform.Rotate(
			0f,
			korpusRotateSpeed * Input.GetAxis("Horizontal"),
			0f
		);

		if ( Input.GetKey(KeyCode.Q)) {
			bash.transform.Rotate(0f, -bashSpeed, 0f);
		}
        if (Input.GetKey(KeyCode.E)) {
            bash.transform.Rotate(0f, bashSpeed, 0f);
        }

		dulo.transform.Rotate(
			-duloSpeed * Input.GetAxis("Mouse Y"),
			0f,
			0f
		);
		
		if (dulo.transform.localEulerAngles.x > 300) {
			dulo.transform.localEulerAngles = new Vector3(
                Mathf.Clamp(dulo.transform.localEulerAngles.x, 356.5f, 360),
				dulo.transform.localEulerAngles.y,
				dulo.transform.localEulerAngles.z
            );
		}
		else {
			dulo.transform.localEulerAngles = new Vector3(
				Mathf.Clamp(dulo.transform.localEulerAngles.x, 0, 15),
				dulo.transform.localEulerAngles.y,
				dulo.transform.localEulerAngles.z
			);
		}

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !movementSound.isPlaying) {
            movementSound.Play(); 
		}
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && movementSound.isPlaying) {
            movementSound.Stop();
		}
    }
}
