using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc_Attack : Attack_Base {
    [Header("Disc Attack")]
    [SerializeField] float travelBackVelocity;
    bool returning = false;

    GameObject hd;
    HD_Behaviour hd_Behaviour;

    // Start is called before the first frame update
   void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        hd = GameObject.FindGameObjectWithTag("Boss");
        hd_Behaviour = hd.GetComponent<HD_Behaviour>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		transform.forward = mainCamera.transform.forward;

        hd_Behaviour.posLocked = true;
        hd_Behaviour.isAttacking = true;

        currentTimeToDestroy = timeToDestroy;
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(0, 0, -30));

        returning = currentTimeToDestroy <= 0 || collidedPlayer ? true : false;

        if (returning) {
            transform.position = Vector3.Lerp(transform.position, hd.transform.position, travelBackVelocity * Time.deltaTime);
            if (collided) {
                hd_Behaviour.posLocked = false;
                hd_Behaviour.isAttacking = false;
                Destroy(gameObject);
            }
        } else {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveVelocity * Time.deltaTime);
        }

        currentTimeToDestroy -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            collidedPlayer = true;

        if (other.tag == "Boss")
            collided = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Boss")
            collided = false;
    }
}
