using UnityEngine;

public class Prefab_ShockAttack : AttackBase {
    // Start is called before the first frame update
    void Awake() {
        colliderObject = gameObject.transform.GetChild(0);
        ps = gameObject.GetComponent<ParticleSystem>();

        currentTimeToDestroy = ps.main.duration;
    }

    // Update is called once per frame
    void FixedUpdate() {
        colliderObject.transform.localScale =
            Vector3.Lerp(colliderObject.transform.localScale, new Vector3(3, 2, 7), Time.deltaTime * 1.5f);

        if (currentTimeToDestroy <= 0)
            Destroy(gameObject);
        else
            currentTimeToDestroy -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collided = true;
            gameManager.PlayerTakeDamage(damage);
        }
    }
}