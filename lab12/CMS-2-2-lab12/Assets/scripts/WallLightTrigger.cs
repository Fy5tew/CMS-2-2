using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLightTrigger : MonoBehaviour {
	public Light pointLight;
	public List<string> detectableObjects = new List<string>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (!detectableObjects.Contains(other.name)) {
			return;
		}
		pointLight.enabled = true;
	}

	void OnTriggerExit (Collider other) {
		if (!detectableObjects.Contains(other.name)) { 
			return;
		}
		pointLight.enabled = false;
	}
}
