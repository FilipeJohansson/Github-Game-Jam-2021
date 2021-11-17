using System.Collections;
using UnityEngine;

public class ThrowFiles : AttackBase, IAttack {

    bool back;
    Vector3 initialPos;

    public ThrowFiles(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GameManager.HD_ThrowFiles, owner.transform.position, owner.transform.rotation);
        owner.GetComponent<BossBase>().canAttack = false;
    }
}

