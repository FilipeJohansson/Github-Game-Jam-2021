using UnityEngine;

public class Prefab_DiscFollowPlayer : AttackBase {
    [SerializeField] float travelBackVelocity;
    bool returning = false;

    HDBehaviour boss;

    // Start is called before the first frame update
   void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject obj in objs)
            if (obj.GetComponent<HDBehaviour>() != null)
                boss = obj.GetComponent<HDBehaviour>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		transform.forward = mainCamera.transform.forward;

        boss.posLocked = true;
        boss.isAttacking = true;

        currentTimeToDestroy = timeToDestroy;
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(0, 0, -30));

        returning = currentTimeToDestroy <= 0 || collidedPlayer ? true : false;

        if (returning) {
            transform.position = Vector3.Lerp(transform.position, boss.transform.position, travelBackVelocity * Time.deltaTime);
            if (collided) {
                boss.posLocked = false;
                boss.isAttacking = false;
                Destroy(gameObject);
            }
        } else {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveVelocity * Time.deltaTime);
        }

        currentTimeToDestroy -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collidedPlayer = true;
            gameManager.PlayerTakeDamage(damage);
        }

        if (other.tag == "Boss")
            collided = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Boss")
            collided = false;
    }
}