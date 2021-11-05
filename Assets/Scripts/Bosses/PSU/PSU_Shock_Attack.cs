using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSU_Shock_Attack : MonoBehaviour {
    Transform colliderObject;
    ParticleSystem ps;

    float timeToDie;

    // Start is called before the first frame update
    void Awake() {
        colliderObject = gameObject.transform.GetChild(0);
        ps = gameObject.GetComponent<ParticleSystem>();

        timeToDie = ps.main.duration;
    }

    // Update is called once per frame
    void FixedUpdate() {
        colliderObject.transform.localScale =
            Vector3.Lerp(colliderObject.transform.localScale, new Vector3(3, 2, 7), Time.deltaTime * 1.5f);

        if (timeToDie <= 0)
            Destroy(gameObject);
        else
            timeToDie -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player hit");
            //other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
}
