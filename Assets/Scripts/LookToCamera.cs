using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour {
    private GameObject mainCamera;

    void FixedUpdate() {
		transform.LookAt(Camera.main.transform);
    }
}
