using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSUBehaviour : BossBase {
    void Awake() {
        attacks = new List<IAttack> {
            new ShockAttack(gameObject)
        };
    }
}
