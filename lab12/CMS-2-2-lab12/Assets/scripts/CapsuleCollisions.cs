using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCollisions : MonoBehaviour {
    public bool changeColor = true;
    public bool changeTexture = true;
    public List<string> detectableObjects = new List<string>();
    public List<Texture> collisionTextures = new List<Texture>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    void OnCollisionEnter (Collision collision) {
        if (detectableObjects.Contains(collision.gameObject.name)) {
            Renderer collisionRenderer = collision.gameObject.GetComponent<Renderer>();

            if (changeColor) {
                collisionRenderer.material.color = new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f)
                );
            }

            if (changeTexture) {
                if (collisionTextures.Count > 0) {
                    int oldTextureIndex = collisionTextures.IndexOf(collisionRenderer.material.mainTexture);
                    int newTextureIndex = Mathf.Clamp(
                        oldTextureIndex + 1,
                        0,
                        collisionTextures.Count - 1
                    );
                    collisionRenderer.material.mainTexture = collisionTextures[newTextureIndex];
                }
            }
        }
    }
}
