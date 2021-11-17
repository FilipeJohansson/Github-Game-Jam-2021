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
    public GameObject ts_PSU_ShockAttack;
    public GameObject ts_PSU_AttackArea;

    [Header("RAM")]
    public GameObject ts_Attack_Binary_0;
    public GameObject ts_Attack_Binary_1;

    [Header("HD")]
    public GameObject ts_HD_ThrowFiles;
    public GameObject ts_HD_DiscAttack;

    // Statics References
    static public GameObject Player;
    static public GameObject GPU_ThrowAttack;
    static public GameObject PSU_ShockAttack;
    static public GameObject PSU_AttackArea;
    static public GameObject Attack_Binary_0;
    static public GameObject Attack_Binary_1;
    static public GameObject HD_ThrowFiles;
    static public GameObject HD_DiscAttack;

    void Start() {
        // Set static references
        GPU_ThrowAttack = ts_GPU_ThrowAttack;
        PSU_ShockAttack = ts_PSU_ShockAttack;
        PSU_AttackArea = ts_PSU_AttackArea;
        Attack_Binary_0 = ts_Attack_Binary_0;
        Attack_Binary_1 = ts_Attack_Binary_1;
        HD_ThrowFiles = ts_HD_ThrowFiles;
        HD_DiscAttack = ts_HD_DiscAttack;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayerTakeDamage(float amount){
        Player.GetComponent<PlayerBehaviour>().TakeDamage(amount);
    }

    public void PlayerReceiveLife(float amount){
        Player.GetComponent<PlayerBehaviour>().ReceiveLife(amount);
    }

    public void RoomEntered(GameObject room)
    {
        Debug.Log(room.name);
    }

    public void RoomExited(GameObject room)
    {
        Debug.Log(room.name);
    }
}