using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSU_Behaviour : Boss_Base {
    void Awake() {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        attacks = new List<IAttack> {
            new PSU_Shock_Attack(gameObject)
        };

        // Start currentTimeToAttack
        attackTimer = attackCooldown;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!posLocked)
            transform.LookAt(player.transform);

        // Verify if can attack
        if (attackTimer <= 0) {
            // Spawn the attack
            SetAttack(attacks[Random.Range(0, attacks.Count)]);
            activeAttack.Attack(this);

            // Reset timeToAttack
            attackTimer = attackCooldown;
        } else
            attackTimer -= Time.deltaTime;
/* 
        if (showingAttackArea) {
            StartCoroutine(ShowAttackArea());
        } */
    }

    void SetAttack(IAttack _attack) {
        activeAttack = _attack;
    }
}
