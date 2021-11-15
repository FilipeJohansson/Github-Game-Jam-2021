using UnityEngine;

public class Binary_Attack : Attack_Base {
    // Start is called before the first frame update
    void Awake() {
        //Assigns the transform of the first child of the Game Object this script is attached to
        spriteChild = gameObject.transform.GetChild(0);
        spriteRenderer = spriteChild.GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = itemsSprite[Random.Range(0, itemsSprite.Length)];
      
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
            Destroy(gameObject); // to don't accumulate binaries in the game
        
        currentTimeToDestroy -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collided = true;
            gm.PlayerTakeDamage(damage);
        }
    }
}