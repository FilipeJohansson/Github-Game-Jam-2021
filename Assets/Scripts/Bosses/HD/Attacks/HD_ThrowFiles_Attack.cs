using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_ThrowFiles_Attack : IAttack {
    GameObject owner;

    public HD_ThrowFiles_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GM.HD_ThrowFiles, owner.transform.position, owner.transform.rotation);
    }
}
