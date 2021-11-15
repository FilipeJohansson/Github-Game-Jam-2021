using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Binary_Attack : IAttack {
    GameObject owner;

    public RAM_Binary_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GM.RAM_Binary, owner.transform.position, owner.transform.rotation);
        owner.GetComponent<BossBase>().canAttack = false;
    }
}