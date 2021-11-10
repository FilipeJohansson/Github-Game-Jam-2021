using UnityEngine;

public class Throw_Attack : Attack_Base {
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

        if (currentTimeToDestroy <= 0 || collided)
            Destroy(gameObject);

        currentTimeToDestroy -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") collided = true;
    }
}