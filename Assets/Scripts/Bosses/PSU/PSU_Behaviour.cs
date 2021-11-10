using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSU_Behaviour : Boss_Base {
    void Awake() {
        attacks = new List<IAttack> {
            new PSU_Shock_Attack(gameObject)
        };
    }
}
