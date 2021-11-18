using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Inspector variables
    [Header("Player")]
    public GameObject ts_Player;

    [Header("GPU")]
    public GameObject ts_GPU_Boss;
    public GameObject ts_GPU_ThrowAttack;

    [Header("PSU")]
    public GameObject ts_PSU_Boss;
    public GameObject ts_PSU_ShockAttack;
    public GameObject ts_PSU_AttackArea;

    [Header("RAM")]
    public GameObject ts_RAM_Boss;
    public GameObject ts_Attack_Binary_0;
    public GameObject ts_Attack_Binary_1;

    [Header("HD")]
    public GameObject ts_HD_Boss;
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
    static public GameObject GPU_Boss;
    static public GameObject PSU_Boss;
    static public GameObject RAM_Boss;
    static public GameObject HD_Boss;

    private string currentRoom;
    private BossStateManager currentStateManager = null;

    void Start() {
        // Set static references
        GPU_ThrowAttack = ts_GPU_ThrowAttack;
        PSU_ShockAttack = ts_PSU_ShockAttack;
        PSU_AttackArea = ts_PSU_AttackArea;
        Attack_Binary_0 = ts_Attack_Binary_0;
        Attack_Binary_1 = ts_Attack_Binary_1;
        HD_ThrowFiles = ts_HD_ThrowFiles;
        HD_DiscAttack = ts_HD_DiscAttack;
        GPU_Boss = ts_GPU_Boss;
        PSU_Boss = ts_PSU_Boss;
        RAM_Boss = ts_RAM_Boss;
        HD_Boss = ts_HD_Boss;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayerTakeDamage(float amount) {
        Player.GetComponent<PlayerBehaviour>().TakeDamage(amount);
    }

    public void PlayerReceiveLife(float amount) {
        Player.GetComponent<PlayerBehaviour>().ReceiveLife(amount);
    }

    public void RoomEntered(GameObject room) {
        currentRoom = room.name;

        switch (currentRoom) {
            case "CPU":
                break;
            case "GPU":
                currentStateManager = GPU_Boss.GetComponent<BossStateManager>();
                break;
            case "PSU":
                currentStateManager = PSU_Boss.GetComponent<BossStateManager>();
                break;
            case "RAM":
                currentStateManager = RAM_Boss.GetComponent<BossStateManager>();
                break;
            case "HD":
                currentStateManager = HD_Boss.GetComponent<BossStateManager>();
                break;
        }

        currentStateManager?.SwitchState(currentStateManager.WakeUpState);
    }

    public void RoomExited() {
        currentStateManager?.SwitchState(currentStateManager.LayState);
        currentStateManager = null;
        currentRoom = null;
    }
}