using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU_Behaviour : Boss_Behaviour {
    [SerializeField] float timeToAttack = 1f;
    float currentTimeToAttack;

    // [SerializeField] GameObject distanceAttack;

    [HideInInspector] public GameObject player;

    [HideInInspector] public bool posLocked = false;

    [SerializeField] float rotationSpeedLookAt = 1f;

    // GPU_Melee_Attack melee_Attack;

    IAttack activeAttack;
    List<IAttack> attacks;

    // Start is called before the first frame update
    void Awake() {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        // melee_Attack = GetComponent<GPU_Melee_Attack>();

        attacks = new List<IAttack> {
			new GPU_Distance_Attack(gameObject),
            new GPU_Melee_Attack(gameObject)
		};

        // Start currentTimeToAttack
        currentTimeToAttack = timeToAttack;
    }

    /* void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine(melee_Attack.DashIntoPlayer());
		}
	} */

    // Update is called once per frame
    void FixedUpdate() {
        // Boss look at the player
        transform.LookAt(player.transform);

        // Verify if can attack
        if (currentTimeToAttack <= 0) {
            // Spawn the attack
            SetAttack(attacks[Random.Range(0, attacks.Count)]);
            activeAttack.Attack(this);
            Debug.Log("Attacking");
			
            // Reset timeToAttack
            currentTimeToAttack = timeToAttack;
        } else
            currentTimeToAttack -= Time.deltaTime;

        if (!posLocked) {
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedLookAt * Time.deltaTime);
        }
    }

    void SetAttack(IAttack _attack) {
        activeAttack = _attack;
    }
}