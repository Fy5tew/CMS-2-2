using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTrigger : MonoBehaviour {
	public GameObject cylinder;
	public Vector3 cylinderRotation = Vector3.zero;
	public List<Light> lights;
	public float intensityStep = 1;
	public float minIntensity = 0;
	public float maxIntensity = 100;
	public List<string> detectableObjects = new List<string>();

    // Use this for initialization
    void Start () {
        foreach (var light in lights) {
            light.intensity = minIntensity;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider other) {
        if (!detectableObjects.Contains(other.name)) {
            return;
        }
		cylinder.transform.Rotate(cylinderRotation);
		foreach (var light in lights) {
			light.intensity = Mathf.Clamp(
				light.intensity + intensityStep,
				minIntensity,
				maxIntensity
			);
			if (light.intensity >= maxIntensity) {
				intensityStep = -intensityStep;
			}
			if (light.intensity <= minIntensity) {
				intensityStep = -intensityStep;
			}
		}
    }

	void OnTriggerExit (Collider other) {
        if (!detectableObjects.Contains(other.name)) {
            return;
        }
		foreach (var light in lights) {
			light.intensity = minIntensity;
		}
    }
}
