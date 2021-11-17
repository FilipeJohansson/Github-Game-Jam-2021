using System.Collections;
using UnityEngine;

public class DashAttack : AttackBase, IAttack {

    bool back;
    Vector3 initialPos;

    public DashAttack(GameObject _owner, float _moveSpeed, bool _back = false) {
        owner = _owner;
        moveSpeed = _moveSpeed;
        back = _back;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(Dash(owner));
    }

    IEnumerator Dash(GameObject _owner) {
        BossBase boss = _owner.GetComponent<BossBase>();

        yield return new WaitForSeconds(0.5f);

        if (back) {
            initialPos = owner.transform.position;
        }

        bool dashing = true;
        boss.posLocked = true; // Lock the enimy's LookAt

        // get the player's position when atack is added (witout update while the dash occur to don't follow the player)
        Vector3 targetV3 = boss.player.transform.position;
        // a vector2 to compare the positions without Y
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // while don't have target or don't touch in the player, walk in target direction
        while (dashing) {
            owner.transform.position = Vector3.Lerp(owner.transform.position, targetV3, moveSpeed * Time.deltaTime);

            // vector2 with enimy postion round
            Vector2 currentPos = new Vector2(Mathf.Round(owner.transform.position.x), Mathf.Round(owner.transform.position.z));

            // if enimy collided with the player or is in the target will break the while
            if (currentPos == targetV2 || collided) {
                if (back) {
                    yield return new WaitForSeconds(1f);

                    while (dashing) {
                        // Lerp to back to initial pos
                        owner.transform.position = Vector3.Lerp(owner.transform.position, initialPos, moveSpeed * Time.deltaTime);

                        currentPos = new Vector2(Mathf.Round(owner.transform.position.x), Mathf.Round(owner.transform.position.z));
                        if (currentPos == new Vector2(Mathf.Round(initialPos.x), Mathf.Round(initialPos.z)))
                            break;
                        else
                            yield return null;
                    }
                }

                break;
            } else
                yield return null;
        }

        boss.posLocked = false;
        boss.canAttack = false;

        yield return null;
    }
}

