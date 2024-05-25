using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public event Action OnDestroing;

	public float speed = 1f;
	public float lifeTime = 5f;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f, 0f, -speed);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Shootable") {
			collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(collision.gameObject.GetComponent<AudioSource>().clip);
			
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			
			Destroy(gameObject);
		}
	}

	void OnDestroy() {
		OnDestroing.Invoke();
	}
}
