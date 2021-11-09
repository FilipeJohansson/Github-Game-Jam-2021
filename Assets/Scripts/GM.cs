using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    // Inspector variables
    public GameObject ts_GPU_Distance_Projectile;
    public GameObject ts_PSU_Shock_Attack;
    public GameObject ts_PSU_Attack_Area;
    public GameObject ts_RAM_Binary;

    // Statics References
    static public GameObject GPU_Distance_Projectile;
    static public GameObject PSU_Shock_Attack;
    static public GameObject PSU_Attack_Area;
    static public GameObject RAM_Binary;

    void Start() {
        // Set static references
        GPU_Distance_Projectile = ts_GPU_Distance_Projectile;
        PSU_Shock_Attack = ts_PSU_Shock_Attack;
        PSU_Attack_Area = ts_PSU_Attack_Area;
        RAM_Binary = ts_RAM_Binary;
    }
}