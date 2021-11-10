using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Behaviour : Boss_Base {
    void Awake() {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        attacks = new List<IAttack> {
            //new HD_Dash_Attack(gameObject),
            //new HD_Disc_Attack(gameObject),
            new HD_ThrowFiles_Attack(gameObject)
        };

        // Start currentTimeToAttack
        attackTimer = attackCooldown;
    }


    void FixedUpdate() {

        if (!posLocked) {
            /* // gira o hd em dire��o ao jogador de forma suave
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeedLookAt * Time.deltaTime); */

            // Boss look at the player
            transform.LookAt(player.transform);
        }

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

    /*  void DiscAttack() {
         Instantiate(_discGO, transform.position, Quaternion.Euler(new Vector3(45, 0, 0)));
     }

     void DashAttack() {
         StartCoroutine(_dashAttack.SpinIntoPlayer());
     }

     void ThrowFilesAttack() {
         Instantiate(_throwFilesGO, transform.position, Quaternion.Euler(new Vector3(45, 0, 0)));
     } */
}
