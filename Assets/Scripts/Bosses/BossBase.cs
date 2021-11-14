using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBase : MonoBehaviour {
    [SerializeField] public GameObject slot;
    [SerializeField] public int health;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float attackRange;
    [SerializeField] public float attackDamage;
    [SerializeField] public GameObject attackArea;
    [SerializeField] public float attackCooldown = 3f;
    [SerializeField] public float attackTimer;
    [SerializeField] public float attackDuration;
    [SerializeField] public float attackDelay = 3f;
    [SerializeField] public float attackDelayTimer;
    [SerializeField] public float rotationSpeedLookAt = 1f;
    [SerializeField] public bool canAttack = false;
    [SerializeField] public bool isAttacking = false;
    [HideInInspector] public bool showingAttackArea = false;
    [HideInInspector] public bool posLocked = false;
    [HideInInspector] public GameObject player;

    public IAttack activeAttack;
    public List<IAttack> attacks;

    void Start() {
        Debug.Log("BossBase Start");
        // Find player object
        FindPlayerObject();
        ResetAttackTimer();
        ResetAttackDelay();
    }

    void FixedUpdate() {
        // Verify if can attack
        /* if (attackTimer <= 0 && !isAttacking) {
            SetAttack();
            Attack();
        } else if (!isAttacking)
            DecreaseAttackCooldown(); */
    }

    public void FindPlayerObject() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LookAtPlayer() {
        transform.LookAt(player.transform);
    }

    public void LookAtPlayerSmooth() {
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedLookAt * Time.deltaTime);
    }

    public void SetAttack() {
        activeAttack = attacks[Random.Range(0, attacks.Count)];
    }

    public void ResetAttackTimer() {
        attackTimer = attackCooldown;
    }

    public void DecreaseAttackTimer() {
        attackTimer -= Time.deltaTime;
    }

    public void ResetAttackDelay() {
        attackDelayTimer = attackDelay;
    }

    public void DecreaseAttackDelay() {
        attackTimer -= Time.deltaTime;
    }

    public void Attack() {
        // isAttacking = true;
        activeAttack.Attack(this);
    }

    public void ShowAttackArea() {
        showingAttackArea = true;
        attackArea.SetActive(true);
    }

    public void HideAttackArea() {
        showingAttackArea = false;
        attackArea.SetActive(false);
    }
    
    public void SetAttackAreaPosition() {
        attackArea.transform.position = transform.position;
    }

    public void SetAttackAreaRotation() {
        attackArea.transform.rotation = transform.rotation;
    }

    public void SetAttackAreaScale() {
        attackArea.transform.localScale = new Vector3(attackRange, 1, attackRange);
    }

    public void SetAttackArea() {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale();
    }

    /* public void SetAttackArea(Vector3 position, Quaternion rotation, Vector3 scale) {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale();
    }

    public void SetAttackArea(Vector3 position, Quaternion rotation, float scale) {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale(scale);
    }

    public void SetAttackArea(Vector3 position, Quaternion rotation, float scaleX, float scaleY, float scaleZ) {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale(scaleX, scaleY, scaleZ);
    }

    public void SetAttackAreaScale(float scale) {
        SetAttackAreaScale(scale, scale, scale);
    }

    public void SetAttackAreaScale(float scaleX, float scaleY, float scaleZ) {
        attackArea.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    } */
}