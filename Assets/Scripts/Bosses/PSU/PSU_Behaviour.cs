using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSU_Behaviour : MonoBehaviour {

    float timeToAttack = 5f;
    float currentTimeToAttack;

    GameObject player;

    [SerializeField]
    GameObject shockWave;

    // Start is called before the first frame update
    void Awake() {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        // Start currentTimeToAttack
        currentTimeToAttack = timeToAttack;
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Boss look at the player
        transform.LookAt(player.transform);

        // Verify if can attack
        if (currentTimeToAttack <= 0) {
            // Spawn the attack
            Instantiate(shockWave, transform.position, transform.rotation);
            // Reset timeToAttack
            currentTimeToAttack = timeToAttack;
        } else
            currentTimeToAttack -= Time.deltaTime;
    }
}
