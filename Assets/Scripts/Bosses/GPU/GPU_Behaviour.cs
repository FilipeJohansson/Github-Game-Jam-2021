using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU_Behaviour : Boss_Base {
    void Awake() {
        attacks = new List<IAttack> {
			new GPU_Distance_Attack(gameObject),
            new GPU_Melee_Attack(gameObject)
		};
    }
}