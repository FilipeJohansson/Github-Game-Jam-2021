using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Binary_Attack : IAttack {
    GameObject owner;

    string[] words = new string[]
    {
        "01100110 01110101 01100011 01101011",
        "01100111 01100101 01110100 00100000 01101111 01110101 01110100"
    };
    string word;

    public RAM_Binary_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        // GameObject.Instantiate(GM.RAM_Binary, owner.transform.position, owner.transform.rotation);
        word = words[Random.Range(0, words.Length)];
        mono.StartCoroutine(ThrowBinary(owner));

        // owner.GetComponent<BossBase>().canAttack = false;
    }

    IEnumerator ThrowBinary(GameObject _owner) {
        BossBase boss = _owner.GetComponent<BossBase>();

        // boss.posLocked = true;
        
        foreach (char c in word) {
            yield return new WaitForSeconds(.2f);
            if (c == '0')
                GameObject.Instantiate(GM.Attack_Binary_0, owner.transform.position, owner.transform.rotation);
            else if (c == '1')
                GameObject.Instantiate(GM.Attack_Binary_1, owner.transform.position, owner.transform.rotation);
            else
                yield return new WaitForSeconds(.3f);
        }

        // boss.posLocked = false;
        boss.canAttack = false;

        yield return null;
    }
}