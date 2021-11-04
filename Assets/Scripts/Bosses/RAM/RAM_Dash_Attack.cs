using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Dash_Attack : MonoBehaviour
{
    public float spinSpeed;

    GameObject player;
    RAM_Behaviour ram_behaviour;
    bool collide;

    private void Start()
    {
        ram_behaviour = GetComponent<RAM_Behaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public IEnumerator SpinIntoPlayer()
    {
        bool dashing = true;
        ram_behaviour.posLocked = true; // Lock the enimy's LookAt

        // get the player's position when atack is added (witout update while the dash occur to don't follow the player)
        Vector3 targetV3 = player.transform.position;
        // a vector2 to compare the positions without Y
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // while don't have target or don't touch in the player, walk in target direction
        while (dashing) 
        {
            collide = false;
            transform.position = Vector3.Lerp(transform.position, targetV3, spinSpeed * Time.deltaTime);

            // vector2 with enimy postion round
            Vector2 currentPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.z));

            // if enimy collide with the player or is in the target will break the while
            if (currentPos == targetV2 ||
                collide)
            {
                break;
            }
            else
            {
                yield return null;
            }

        }

        ram_behaviour.posLocked = false;
    }

    void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player")
			collide = true;
	}

}

