using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Binary_Attack : IAttack {
    GameObject owner;

    string[] words = new string[]
    {
        "01100110 01110101 01100011 01101011",
        "01100111 01100101 01110100 00100000 01101111 01110101 01110100",
        "01111001 01101111 01110101 00100111 01110010 01100101 00100000 01100001 00100000 01110011 01101000 01101001 01110100 00100001",
        "01101001 00100111 01101100 01101100 00100000 01101011 01101001 01101100 01101100 00100000 01111001 01101111 01110101",
        "01100100 01101001 01100101 00100001 00100000 01100100 01101001 01100101 00100001",
        "01111001 01101111 01110101 01110010 00100000 01100010 01100001 01110011 01110100 01100001 01110010 01100100 00100001"
    };
    string word;

    public RAM_Binary_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        // GameObject.Instantiate(GameManager.RAM_Binary, owner.transform.position, owner.transform.rotation);
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
                GameObject.Instantiate(GameManager.Attack_Binary_0, owner.transform.position, owner.transform.rotation);
            else if (c == '1')
                GameObject.Instantiate(GameManager.Attack_Binary_1, owner.transform.position, owner.transform.rotation);
            else
                yield return new WaitForSeconds(.3f);
        }

        // boss.posLocked = false;
        boss.canAttack = false;

        yield return null;
    }
}