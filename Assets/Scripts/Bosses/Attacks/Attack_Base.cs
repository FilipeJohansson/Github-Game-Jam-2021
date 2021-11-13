using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_Base : MonoBehaviour {
    [Header("Context Attributes")]
    [SerializeField] protected GameObject player;
    [SerializeField] protected Vector3 target;
    protected GameObject mainCamera;

    [Header("Damage Attributes")]
    [SerializeField] protected float damage = 1f;

    [Header("Move Attributes")]
    [SerializeField] protected float rotationVelocity = 400f;
    [SerializeField] protected float moveVelocity = 10f;

    [Header("Time Attributes")]
    [SerializeField] protected float timeToDestroy = 5f;
    [SerializeField] protected float currentTimeToDestroy;

    [Header("Sprite Attributes")]
    [SerializeField] protected Sprite[] itemsSprite;
    
    [SerializeField] protected SpriteRenderer spriteRenderer;
    
    [Header("Collider Attributes")]
    [SerializeField] protected Transform colliderObject;
    [SerializeField] protected bool collided = false;
    [SerializeField] protected bool collidedPlayer = false;

    [Header("Sprite Attributes")]
    protected Transform spriteChild;

    [Header("Particle System Attributes")]
    [SerializeField] protected ParticleSystem ps;
}