using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDBehaviour : BossBase {
    void Awake() {
        attacks = new List<IAttack> {
            // new HD_Dash_Attack(gameObject),
            // new HD_Disc_Attack(gameObject),
            new ThrowFiles(gameObject)
        };
    }
}