using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Dash_Attack : Attack_Base, IAttack {
    GameObject owner;

    [SerializeField] float spinSpeed = 10f;

    public RAM_Dash_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(DashIntoPlayer(owner));
    }

    IEnumerator DashIntoPlayer(GameObject _owner) {
        RAM_Behaviour ram_Behaviour = _owner.GetComponent<RAM_Behaviour>();

        yield return new WaitForSeconds(0.5f);

        bool dashing = true;
        ram_Behaviour.posLocked = true; // Lock the enimy's LookAt

        // get the player's position when atack is added (witout update while the dash occur to don't follow the player)
        Vector3 targetV3 = ram_Behaviour.player.transform.position;
        // a vector2 to compare the positions without Y
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // while don't have target or don't touch in the player, walk in target direction
        while (dashing) {
            owner.transform.position = Vector3.Lerp(owner.transform.position, targetV3, spinSpeed * Time.deltaTime);

            // vector2 with enimy postion round
            Vector2 currentPos = new Vector2(Mathf.Round(owner.transform.position.x), Mathf.Round(owner.transform.position.z));

            // if enimy collided with the player or is in the target will break the while
            if (currentPos == targetV2 || collided) {
                break;
            } else {
                yield return null;
            }

        }

        ram_Behaviour.posLocked = false;
        ram_Behaviour.canAttack = false;

        yield return null;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" || other.tag == "Enemy") {
            collided = true;
            if (other.tag == "Player")
                gameManager.PlayerTakeDamage(damage);
        }
    }
}

