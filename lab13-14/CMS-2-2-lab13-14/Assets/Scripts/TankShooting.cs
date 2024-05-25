using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {
	public GameObject bulletPrefab;

	bool canShoot = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && canShoot) {
			GameObject bullet = Instantiate(
				bulletPrefab,
				transform.position + transform.TransformDirection(0, 0, -2),
				transform.rotation
			);
			bullet.GetComponent<BulletScript>().OnDestroing += Reload;

			GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);

			canShoot = false;
		}
	}

	void Reload() {
		canShoot = true;
	}
}
