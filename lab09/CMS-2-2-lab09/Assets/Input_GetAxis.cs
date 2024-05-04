using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour {
	float _translateX, _translateZ;
	float _rotateX, _rotateY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_translateX = Input.GetAxis("Horizontal");
		_translateZ = Input.GetAxis("Vertical");

		_rotateX = Input.GetAxis("Mouse X");
		_rotateY = Input.GetAxis("Mouse Y");

		_rotateY = Mathf.Clamp(_rotateY, 0, 90);

		transform.Translate(_translateX, 0, _translateZ);
		transform.Rotate(_rotateX, _rotateY, 0);
	}
}
