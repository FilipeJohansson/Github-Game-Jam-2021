using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss_Base : MonoBehaviour {
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected int speed;
    [SerializeField] protected int attackSpeed;
    [SerializeField] protected int attackRange;
    [SerializeField] protected int attackDamage;
    [SerializeField] public GameObject attackArea;
    [SerializeField] protected float attackCooldown = 3f;
    [SerializeField] protected float attackTimer;
    [SerializeField] protected int attackDuration;
    [SerializeField] protected int attackDelay;
    [SerializeField] protected float rotationSpeedLookAt = 1f;
    [SerializeField] public bool isAttacking = false;
    [HideInInspector] protected bool showingAttackArea = false;
    [HideInInspector] public bool posLocked = false;
    [HideInInspector] public GameObject player;

    protected IAttack activeAttack;
    protected List<IAttack> attacks;

    void Start() {
        // Find player object
        FindPlayerObject();
        ResetAttackCooldown();
    }

    void FixedUpdate() {
        if (!posLocked)
            LookAtPlayer();

        // Verify if can attack
        if (attackTimer <= 0 && !isAttacking) {
            SetAttack();
            Attack();
        } else if (!isAttacking)
            DecreaseAttackCooldown();
    }

    protected void FindPlayerObject() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void LookAtPlayer() {
        transform.LookAt(player.transform);
    }

    protected void LookAtPlayerSmooth() {
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedLookAt * Time.deltaTime);
    }

    protected void SetAttack() {
        activeAttack = attacks[Random.Range(0, attacks.Count)];
    }

    protected void ResetAttackCooldown() {
        attackTimer = attackCooldown;
    }

    protected void DecreaseAttackCooldown() {
        attackTimer -= Time.deltaTime;
    }

    protected void Attack() {
        // isAttacking = true;
        activeAttack.Attack(this);
        ResetAttackCooldown();
    }

    protected void ShowAttackArea() {
        showingAttackArea = true;
        attackArea.SetActive(true);
    }

    protected void HideAttackArea() {
        showingAttackArea = false;
        attackArea.SetActive(false);
    }
    
    protected void SetAttackAreaPosition() {
        attackArea.transform.position = transform.position;
    }

    protected void SetAttackAreaRotation() {
        attackArea.transform.rotation = transform.rotation;
    }

    protected void SetAttackAreaScale() {
        attackArea.transform.localScale = new Vector3(attackRange, 1, attackRange);
    }

    protected void SetAttackArea() {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale();
    }

    /* protected void SetAttackArea(Vector3 position, Quaternion rotation, Vector3 scale) {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale();
    }

    protected void SetAttackArea(Vector3 position, Quaternion rotation, float scale) {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale(scale);
    }

    protected void SetAttackArea(Vector3 position, Quaternion rotation, float scaleX, float scaleY, float scaleZ) {
        SetAttackAreaPosition();
        SetAttackAreaRotation();
        SetAttackAreaScale(scaleX, scaleY, scaleZ);
    }

    protected void SetAttackAreaScale(float scale) {
        SetAttackAreaScale(scale, scale, scale);
    }

    protected void SetAttackAreaScale(float scaleX, float scaleY, float scaleZ) {
        attackArea.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    } */
}