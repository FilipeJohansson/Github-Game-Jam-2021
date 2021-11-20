using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    [SerializeField] private Transform sprite;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float range = 100f;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackTimer;

    public bool isFacing = true;

    float angle;

    void Awake() {
        //sprite = transform.Find("Sprite");

        attackTimer = attackCooldown;
    }

    void Update() {
        AimMouse();

        if (Input.GetMouseButtonDown(0) && canShoot) {
            Shoot();
            ResetAttackTimer();
            canShoot = false;
        }

        if (attackTimer <= 0)
            canShoot = true;
        else
            attackTimer -= Time.deltaTime;



        float dot = Vector3.Dot(transform.forward, (Camera.main.transform.position - transform.position).normalized);
        if (dot < -0.1f && isFacing)
            Flip();
        else if (dot > 0.1f && !isFacing)
            Flip();
    }

    void FixedUpdate() {

    }

    private void Shoot() {
        GameObject bullet = Instantiate(GameManager.PlayerBullet, sprite.position, transform.rotation) as GameObject;
        // bullet.GetComponent<Bullet>().SetDamage(10);
    }

    public void ResetAttackTimer() {
        attackTimer = attackCooldown;
    }

    void AimMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, layerMask)) {
            angle = Vector3.Angle(transform.forward, hit.point - transform.position);
            if (angle < 90) {
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
    }

    void Flip() {
        isFacing = !isFacing;

        Vector3 Scaler = sprite.transform.localScale;
        Scaler.x *= -1;
        Scaler.y *= -1;
        sprite.transform.localScale = Scaler;
    }

}