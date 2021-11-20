using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookToCamera : MonoBehaviour {
    float x;
    bool isFacing = true;

    void Awake() {
        x = -45;
    }

    void Update() {
        transform.rotation = Quaternion.Euler(x, 0, 0);
    }

    void FixedUpdate() {
        float dot = Vector3.Dot(transform.forward, (Camera.main.transform.position - transform.position).normalized);
        if (dot < -0.1f && isFacing)
            Flip();
		else if (dot > 0.1f && !isFacing)
			Flip();
    }

    [ContextMenu("Flip")]
    void Flip() {
        isFacing = !isFacing;

        Vector3 Scaler = transform.localScale;
        Scaler.z *= -1;
        x *= -1;

        transform.localScale = Scaler;
    }
}
