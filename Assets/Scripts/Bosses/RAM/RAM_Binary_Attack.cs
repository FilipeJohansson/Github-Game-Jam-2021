using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Binary_Attack : MonoBehaviour {
    Transform spriteChild;
	SpriteRenderer spriteRenderer;
    [SerializeField]
	float rotationVelocity = 50f;
	[SerializeField]
	float moveVelocity = 10f;
	[SerializeField]
	float timeToDestroy = 5f;
	[SerializeField]
	float currentTimeToDestroy;

	[SerializeField]
	Sprite[] itemsSprite; // the bits 0 and 1

	GameObject mainCamera;

	// Start is called before the first frame update
	void Awake() {
        //Assigns the transform of the first child of the Game Object this script is attached to
        Debug.Log("transform.childCount " + transform.childCount);

		spriteChild = gameObject.transform.GetChild(0);
		spriteRenderer = spriteChild.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = itemsSprite[Random.Range(0, itemsSprite.Length)];

		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		spriteChild.transform.forward = mainCamera.transform.forward;

		currentTimeToDestroy = timeToDestroy; 
	}

	// Update is called once per frame
	void FixedUpdate() {
        // Rotate the sprite on z axies
		spriteChild.transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationVelocity));
		// Translate the object to front
		transform.Translate(Vector3.forward * Time.deltaTime * moveVelocity);

		if (currentTimeToDestroy <= 0)
			Destroy(gameObject); // to don't accumulate binaries in the game
		else
			currentTimeToDestroy -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player")
			Destroy(gameObject);
	}
}