using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Inspector variables
    [Header("Player")]
    public GameObject ts_Player;

    [Header("GPU")]
    public GameObject ts_GPU_ThrowAttack;
    
    [Header("PSU")]
    public GameObject ts_PSU_Shock_Attack;
    public GameObject ts_PSU_Attack_Area;

    [Header("RAM")]
    public GameObject ts_Attack_Binary_0;
    public GameObject ts_Attack_Binary_1;

    [Header("HD")]
    public GameObject ts_HD_ThrowFiles;
    public GameObject ts_HD_Disc_Attack;

    // Statics References
    static public GameObject Player;
    static public GameObject GPU_ThrowAttack;
    static public GameObject PSU_Shock_Attack;
    static public GameObject PSU_Attack_Area;
    static public GameObject Attack_Binary_0;
    static public GameObject Attack_Binary_1;
    static public GameObject HD_ThrowFiles;
    static public GameObject HD_Disc_Attack;

    void Start() {
        // Set static references
        GPU_ThrowAttack = ts_GPU_ThrowAttack;
        PSU_Shock_Attack = ts_PSU_Shock_Attack;
        PSU_Attack_Area = ts_PSU_Attack_Area;
        Attack_Binary_0 = ts_Attack_Binary_0;
        Attack_Binary_1 = ts_Attack_Binary_1;
        HD_ThrowFiles = ts_HD_ThrowFiles;
        HD_Disc_Attack = ts_HD_Disc_Attack;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayerTakeDamage(float amount){
        Player.GetComponent<PlayerBehaviour>().TakeDamage(amount);
    }

        public void PlayerReceiveLife(float amount){
        Player.GetComponent<PlayerBehaviour>().ReceiveLife(amount);
    }
}