using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUBehaviour : BossBase {
    float dashSpeed = 10f;
    
    void Awake() {
        attacks = new List<IAttack> {
			new ThrowAttack(gameObject),
            new DashAttack(gameObject, dashSpeed, true)
		};
    }
}