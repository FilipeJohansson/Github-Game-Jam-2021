using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Files : Attack_Base {
    // Start is called before the first frame update
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;

        spriteChild = gameObject.transform.GetChild(0);
		spriteRenderer = spriteChild.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = itemsSprite[Random.Range(0, itemsSprite.Length)];

		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		spriteChild.transform.forward = mainCamera.transform.forward;

        currentTimeToDestroy = timeToDestroy;
    }

    void FixedUpdate() {
        // transform.Translate(Vector3.forward * Time.deltaTime * moveVelocity);
        transform.position = Vector3.Lerp(transform.position, target, moveVelocity * Time.deltaTime);

        if (currentTimeToDestroy <= 0 || collided) {
            if (spriteRenderer.sprite.name == "fileBat" && collided) {
                //TODO: Acionar efeito no player (slow, dano reduzido ou algo assim sei la)
                Debug.Log("Player has collided to .bat file");
            }

            Destroy(gameObject);
        }

        currentTimeToDestroy -= Time.deltaTime;

        /* if (_currentTimeToDestroy <= 0 || collided) {
            if (_chosenFileSprite.name != "fileBat.png") {
                //TODO: Acionar efeito no player (slow, dano reduzido ou algo assim sei la)
            }

            Destroy(gameObject);
        } else {
            // viaja ate o player
            transform.position = Vector3.Lerp(transform.position, target, _travelSpeed * Time.deltaTime);
            _currentTimeToDestroy -= Time.deltaTime;
        } */
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") collided = true;
    }
}
