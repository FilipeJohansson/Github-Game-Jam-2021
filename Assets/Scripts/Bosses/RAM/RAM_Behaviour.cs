using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Behaviour : MonoBehaviour {
    // to attack the player
	GameObject player;

    // to binary attach
    [SerializeField]
	float timeToAttack = 3f;
	float currentTimeToAttack;

	[SerializeField]
	GameObject binaryAttack;

    // to dash attack
    public float rotationSpeedLookAt;

    RAM_Dash_Attack dash_Attack;

    [HideInInspector]
    public bool posLocked = false;
    
    void Start(){
        dash_Attack = GetComponent<RAM_Dash_Attack>();
    }


    // Start is called before the first frame update
	void Awake() {
		// Find player object
		player = GameObject.FindGameObjectWithTag("Player");

		// Start currentTimeToAttack
		currentTimeToAttack = timeToAttack;
	}

    void Update(){
        // Boss look at the player
		transform.LookAt(player.transform);

        // Verify if can attack
		if (currentTimeToAttack <= 0) {
            int attack = Random.Range(0, 2);
            Debug.Log("distance attack " + attack);
            if(attack == 0)
                StartCoroutine(dash_Attack.SpinIntoPlayer());
            else {
                // Spawn the attack
                Instantiate(binaryAttack, transform.position, transform.rotation);
                // Reset timeToAttack
                currentTimeToAttack = timeToAttack;
            }

            // reset time to attack
            currentTimeToAttack = timeToAttack;
		} else
			currentTimeToAttack -= Time.deltaTime;
    }

	// Update is called once per frame
	void FixedUpdate() {
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedLookAt * Time.deltaTime);		
	}



}