using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Behaviour : Boss_Base {
    void Awake() {
        attacks = new List<IAttack> {
            //new HD_Dash_Attack(gameObject),
            new HD_Disc_Attack(gameObject),
            new HD_ThrowFiles_Attack(gameObject)
        };
    }

    /*  void DiscAttack() {
         Instantiate(_discGO, transform.position, Quaternion.Euler(new Vector3(45, 0, 0)));
     }

     void DashAttack() {
         StartCoroutine(_dashAttack.SpinIntoPlayer());
     }

     void ThrowFilesAttack() {
         Instantiate(_throwFilesGO, transform.position, Quaternion.Euler(new Vector3(45, 0, 0)));
     } */
}