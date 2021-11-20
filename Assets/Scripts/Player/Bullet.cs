using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] protected GameManager gameManager;
    [SerializeField] float timeToDestroy = 5f;
    [SerializeField] float currentTimeToDestroy;
    [SerializeField] float speed = 20f;
    [SerializeField] float damage;
    [SerializeField] bool collided = false;

    void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        currentTimeToDestroy = timeToDestroy;
    }

    void FixedUpdate() {
        // Translate the object to front
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (currentTimeToDestroy <= 0 || collided)
            Destroy(gameObject);

        currentTimeToDestroy -= Time.deltaTime;
    }

    public void SetDamage(float _damage) {
        this.damage = _damage;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Boss") {
            collided = true;
            gameManager.BossTakeDamage(other.gameObject, damage);
        }
    }
}
