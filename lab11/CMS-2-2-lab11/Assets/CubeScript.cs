using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeScript : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData) {
        gameObject.GetComponent<Renderer>().material.color = new Color(
            Random.Range(0f, 1f),
			Random.Range(0f, 1f),
			Random.Range(0f, 1f)
		);

		int force = 500;

        Vector3 target = eventData.pointerPressRaycast.worldPosition;
		Vector3 camera = Camera.main.transform.position;
		Vector3 distance = (target - camera).normalized;
		Vector3 collid = distance * force;

		gameObject.GetComponent<Rigidbody>().AddForceAtPosition(collid, target);
    }
}
