using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Dash_Attack : IAttack {
    GameObject owner;
    [SerializeField] float spinSpeed = 5f;

    public RAM_Dash_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(DashIntoPlayer(owner));
    }

    IEnumerator DashIntoPlayer(GameObject _owner) {
        RAM_Behaviour ram = _owner.GetComponent<RAM_Behaviour>();

        bool collide;
        bool dashing = true;
        ram.posLocked = true; // Lock the enimy's LookAt

        // get the player's position when atack is added (witout update while the dash occur to don't follow the player)
        Vector3 targetV3 = ram.player.transform.position;
        // a vector2 to compare the positions without Y
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // while don't have target or don't touch in the player, walk in target direction
        while (dashing) {
            collide = false;
            owner.transform.position = Vector3.Lerp(owner.transform.position, targetV3, spinSpeed * Time.deltaTime);

            // vector2 with enimy postion round
            Vector2 currentPos = new Vector2(Mathf.Round(owner.transform.position.x), Mathf.Round(owner.transform.position.z));

            // if enimy collide with the player or is in the target will break the while
            if (currentPos == targetV2 || collide) {
                break;
            } else {
                yield return null;
            }

        }

        ram.posLocked = false;

        yield return null;
    }

    /* void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
            collide = true;
    } */
}

