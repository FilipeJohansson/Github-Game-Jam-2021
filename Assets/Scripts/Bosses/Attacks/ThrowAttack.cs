using System.Collections;
using UnityEngine;

public class ThrowAttack : AttackBase, IAttack {

    bool back;
    Vector3 initialPos;

    public ThrowAttack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GameManager.GPU_ThrowAttack, owner.transform.position, owner.transform.rotation);
        owner.GetComponent<BossBase>().canAttack = false;
    }
}

