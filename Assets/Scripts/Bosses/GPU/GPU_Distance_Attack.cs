using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU_Distance_Attack : MonoBehaviour {
	Transform spriteChild;
	SpriteRenderer spriteRenderer;
	[SerializeField]
	float rotationVelocity = 400f;
	[SerializeField]
	float moveVelocity = 10f;
	[SerializeField]
	float timeToDestroy = 5f;
	[SerializeField]
	float currentTimeToDestroy;

	[SerializeField]
	Sprite[] itemsSprite;

	GameObject mainCamera;

	// Start is called before the first frame update
	void Awake() {
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
			Destroy(gameObject);
		else
			currentTimeToDestroy -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player")
			Destroy(gameObject);
	}
}
