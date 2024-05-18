using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
	public List<GameObject> doors = new List<GameObject>();
	public List<Vector3> doorsOpenedOffsets = new List<Vector3>();
    public List<string> detectableObjects = new List<string>();

	public GameObject levitator;
	public Vector3 levitatorMovement = Vector3.zero;
	public Vector3 levitatorRotation = Vector3.zero;
	public string levitatorDeteactableObject;

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
		for (int i = 0; i < doors.Count; i++) {
			if (doorsOpenedOffsets.Count <= i) {
				continue;
			}
			doors[i].transform.position += doorsOpenedOffsets[i];
		}
    }

	void OnTriggerExit (Collider other) {
        if (!detectableObjects.Contains(other.name)) {
            return;
        }
        for (int i = 0; i < doors.Count; i++) {
            doors[i].transform.position -= doorsOpenedOffsets[i];
        }
    }

	void OnTriggerStay (Collider other) {
		if (other.name != levitatorDeteactableObject) {
			return;
		}
		levitator.transform.Translate(levitatorMovement);
		levitator.transform.Rotate(levitatorRotation);
	}
}
