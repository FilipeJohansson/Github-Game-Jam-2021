using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    // Inspector variables
    public GameObject ts_GPU_Distance_Projectile;

    // Statics References
    static public GameObject GPU_Distance_Projectile;

    void Start() {
        // Set static references
        GPU_Distance_Projectile = ts_GPU_Distance_Projectile;
    }
}