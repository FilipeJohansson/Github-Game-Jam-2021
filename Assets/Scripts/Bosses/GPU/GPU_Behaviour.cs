using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU_Behaviour : Boss_Base {
    void Awake() {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        attacks = new List<IAttack> {
			new GPU_Distance_Attack(gameObject),
            new GPU_Melee_Attack(gameObject)
		};

        // Start currentTimeToAttack
        attackTimer = attackCooldown;
    }

    void FixedUpdate() {
        // Boss look at the player
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
    }

    void SetAttack(IAttack _attack) {
        activeAttack = _attack;
    }
}