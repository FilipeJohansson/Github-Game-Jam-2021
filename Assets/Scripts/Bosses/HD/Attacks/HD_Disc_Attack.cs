using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Disc_Attack : IAttack {
    GameObject owner;

    public HD_Disc_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GM.HD_Disc_Attack, owner.transform.position, owner.transform.rotation);
    }
}