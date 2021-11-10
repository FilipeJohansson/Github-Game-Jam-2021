using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Behaviour : Boss_Base {
    void Awake() {
        attacks = new List<IAttack> {
            new HD_Dash_Attack(gameObject),
            new HD_Disc_Attack(gameObject),
            new HD_ThrowFiles_Attack(gameObject)
        };
    }
}