using System.Collections;
using UnityEngine;

public class DiscAttack : AttackBase, IAttack {

    bool back;
    Vector3 initialPos;

    public DiscAttack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GameManager.HD_DiscAttack, owner.transform.position, owner.transform.rotation);
        owner.GetComponent<BossBase>().canAttack = false;
    }
}

