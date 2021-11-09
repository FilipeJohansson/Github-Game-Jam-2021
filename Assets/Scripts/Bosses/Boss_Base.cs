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
    [SerializeField] protected float attackCooldown = 3f;
    [SerializeField] protected float attackTimer;
    /* [SerializeField] protected float timeToAttack = 1f;
    [SerializeField] protected float currentTimeToAttack; */
    [SerializeField] protected int attackDuration;
    [SerializeField] protected int attackDelay;
    [SerializeField] protected float rotationSpeedLookAt = 1f;
    [HideInInspector] public bool posLocked = false;
    [HideInInspector] public GameObject player;

    protected IAttack activeAttack;
    protected List<IAttack> attacks;
}