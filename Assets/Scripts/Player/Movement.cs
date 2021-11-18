using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            this.transform.position = transform.position + new Vector3(0, 0, speed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            this.transform.position = transform.position + new Vector3(0, 0, -speed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            this.transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            this.transform.position = transform.position + new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }
}
