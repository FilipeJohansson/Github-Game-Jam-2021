using System.Collections;
using UnityEngine;

public class PSU_Behaviour : Boss_Behaviour {

    float timeToAttack = 5f;
    float currentTimeToAttack;

    GameObject player;

    [SerializeField]
    GameObject shockWave;
    [SerializeField]
    GameObject attackArea;
    bool showAttackArea = false;

    bool lookingToPlayer = true;

    GameObject mainCamera;
    public bool isFacing = true;

    // Start is called before the first frame update
    void Awake() {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        // Start currentTimeToAttack
        currentTimeToAttack = timeToAttack;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (lookingToPlayer) {
            // Rotate towards player
            transform.LookAt(player.transform);
        }

        // Verify if can attack
        if (currentTimeToAttack <= 0) {
            StartCoroutine(ShockAttack());
        } else
            currentTimeToAttack -= Time.deltaTime;

        if(showAttackArea) {
             StartCoroutine(ShowAttackArea());
        }
    }

    IEnumerator ShockAttack() {
        lookingToPlayer = false;
        // Reset timeToAttack
        currentTimeToAttack = timeToAttack;

        showAttackArea = true;

        yield return new WaitForSeconds(1f);

        showAttackArea = false;

        // Spawn the attack
        Instantiate(shockWave, transform.position, transform.rotation);

        yield return new WaitForSeconds(.5f);

        lookingToPlayer = true;

        yield return null;
    }

    IEnumerator ShowAttackArea() {
        attackArea.SetActive(true);
        attackArea.GetComponentInChildren<SpriteRenderer>().material.color = new Color(1, 1, 1, .7f);

        yield return new WaitForSeconds(1.5f);

        attackArea.SetActive(false);

        yield return null;
    }
}
