using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAMBehaviour : BossBase {
    float dashSpeed = 20f;

    void Awake() {
        attacks = new List<IAttack> {
            new ThrowBinaryAttack(gameObject),
            new DashAttack(gameObject, dashSpeed)
        };
    }
}