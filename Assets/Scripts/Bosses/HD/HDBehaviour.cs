using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDBehaviour : BossBase {
    float dashSpeed = 7f;

    void Awake() {
        attacks = new List<IAttack> {
            new DashAttack(gameObject, dashSpeed, false, true),
            new DiscAttack(gameObject),
            new ThrowFiles(gameObject)
        };
    }
}