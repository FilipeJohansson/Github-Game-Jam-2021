using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Behaviour : Boss_Base {
	void Awake() {
		// Find player object
		player = GameObject.FindGameObjectWithTag("Player");

        attacks = new List<IAttack> {
            new RAM_Binary_Attack(gameObject),
            new RAM_Dash_Attack(gameObject)
        };

		// Start currentTimeToAttack
		attackTimer = attackCooldown;
	}

    void FixedUpdate(){
        // Boss look at the player
		if (!posLocked)
            transform.LookAt(player.transform);

        // Verify if can attack
		if (attackTimer <= 0) {
            // Spawn the attack
            SetAttack(attacks[Random.Range(0, attacks.Count)]);
            activeAttack.Attack(this);

            // reset time to attack
            attackTimer = attackCooldown;
		} else
			attackTimer -= Time.deltaTime;
    }

    void SetAttack(IAttack _attack) {
        activeAttack = _attack;
    }
}