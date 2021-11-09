using UnityEngine;

public class Shock_Attack : Attack_Base {
    // Start is called before the first frame update
    void Awake() {
        colliderObject = gameObject.transform.GetChild(0);
        ps = gameObject.GetComponent<ParticleSystem>();

        currentTimeToDestroy = ps.main.duration;
    }

    // Update is called once per frame
    void FixedUpdate() {
        colliderObject.transform.localScale =
            Vector3.Lerp(colliderObject.transform.localScale, new Vector3(3, 2, 7), Time.deltaTime * 1.5f);

        if (currentTimeToDestroy <= 0)
            Destroy(gameObject);
        else
            currentTimeToDestroy -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player hit");
            //other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
}