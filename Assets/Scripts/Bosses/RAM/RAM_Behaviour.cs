using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM_Behaviour : BossBase {
	void Awake() {
        attacks = new List<IAttack> {
            new RAM_Binary_Attack(gameObject)
            // new RAM_Dash_Attack(gameObject)
        };
	}
}