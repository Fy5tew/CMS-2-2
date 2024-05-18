using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightTrigger : MonoBehaviour {
	public Light spotLight;
	public float rotationSpeed = 1;
    public List<string> detectableObjects = new List<string>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider other) {
        if (!detectableObjects.Contains(other.name)) {
            return;
        }
		spotLight.transform.Rotate(rotationSpeed * Vector3.up);
    }
}
