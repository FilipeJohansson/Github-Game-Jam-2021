using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_Base : MonoBehaviour {
    [SerializeField] protected float rotationVelocity = 400f;
    [SerializeField] protected float moveVelocity = 10f;
    [SerializeField] protected float timeToDestroy = 5f;
    [SerializeField] protected float currentTimeToDestroy;
    [SerializeField] protected Sprite[] itemsSprite;

    [SerializeField] protected Transform colliderObject;
    [SerializeField] protected ParticleSystem ps;

    protected Transform spriteChild;
    protected SpriteRenderer spriteRenderer;
    protected GameObject mainCamera;
}