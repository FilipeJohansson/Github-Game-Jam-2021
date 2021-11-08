using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_Base : MonoBehaviour {
    protected Transform spriteChild;
    protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float rotationVelocity = 400f;
    [SerializeField] protected float moveVelocity = 10f;
    [SerializeField] protected float timeToDestroy = 5f;
    [SerializeField] protected float currentTimeToDestroy;

    [SerializeField] protected Sprite[] itemsSprite;

    protected GameObject mainCamera;
}