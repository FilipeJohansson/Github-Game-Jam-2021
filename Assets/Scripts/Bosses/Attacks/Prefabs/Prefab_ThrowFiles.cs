using UnityEngine;

public class Prefab_ThrowFiles : AttackBase {
    Vector3 target;

    // Start is called before the first frame update
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;

        //Assigns the transform of the first child of the Game Object this script is attached to
        spriteChild = gameObject.transform.GetChild(0);
        spriteRenderer = spriteChild.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemsSprite[Random.Range(0, itemsSprite.Length)];

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        spriteChild.transform.forward = mainCamera.transform.forward;

        currentTimeToDestroy = timeToDestroy;
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target, moveVelocity * Time.deltaTime);

        if (currentTimeToDestroy <= 0 || collided) {
            if (spriteRenderer.sprite.name == "fileBat" && collided) {
                //TODO: Acionar efeito no player (slow, dano reduzido ou algo assim sei la)
                Debug.Log("Player has collided to .bat file");
            }

            Destroy(gameObject);
        }

        currentTimeToDestroy -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collided = true;
            gameManager.PlayerTakeDamage(damage);
        }
    }
}