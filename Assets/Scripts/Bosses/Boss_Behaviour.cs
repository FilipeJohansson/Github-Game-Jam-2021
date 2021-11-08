using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss_Behaviour : MonoBehaviour {
    [SerializeField] int health;
    [SerializeField] int damage;
    [SerializeField] int speed;
    [SerializeField] int attackSpeed;
    [SerializeField] int attackRange;
    [SerializeField] int attackDamage;
    [SerializeField] int attackCooldown;
    [SerializeField] int attackDuration;
    [SerializeField] int attackDelay;
}