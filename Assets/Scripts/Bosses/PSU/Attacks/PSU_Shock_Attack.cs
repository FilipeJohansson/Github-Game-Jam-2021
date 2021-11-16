using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSU_Shock_Attack : IAttack {
    GameObject owner;

    public PSU_Shock_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(ShockAttack(owner));
    }

    IEnumerator ShockAttack(GameObject _owner) {
        PSU_Behaviour psu_Behaviour = _owner.GetComponent<PSU_Behaviour>();

        psu_Behaviour.posLocked = true;
        psu_Behaviour.isAttacking = true;

        GameManager.PSU_Attack_Area.SetActive(true);
        GameManager.PSU_Attack_Area.GetComponentInChildren<SpriteRenderer>().material.color = new Color(1, 1, 1, .7f);

        yield return new WaitForSeconds(1.5f);

        GameManager.PSU_Attack_Area.SetActive(false);

        // Spawn the attack
        GameObject.Instantiate(GameManager.PSU_Shock_Attack, owner.transform.position, owner.transform.rotation);

        yield return new WaitForSeconds(.5f);

        psu_Behaviour.posLocked = false;
        psu_Behaviour.isAttacking = false;

        yield return null;
    }
}
