using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockAttack : AttackBase, IAttack {

    public ShockAttack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(Shock(owner));
    }

    IEnumerator Shock(GameObject _owner) {
        BossBase boss = _owner.GetComponent<BossBase>();

        boss.posLocked = true;

        GameManager.PSU_AttackArea.SetActive(true);
        GameManager.PSU_AttackArea.GetComponentInChildren<SpriteRenderer>().material.color = new Color(1, 1, 1, .7f);

        yield return new WaitForSeconds(1.5f);

        GameManager.PSU_AttackArea.SetActive(false);

        // Spawn the attack
        GameObject.Instantiate(GameManager.PSU_ShockAttack, owner.transform.position, owner.transform.rotation);

        yield return new WaitForSeconds(.5f);

        boss.posLocked = false;
        boss.canAttack = false;

        yield return null;
    }
}
