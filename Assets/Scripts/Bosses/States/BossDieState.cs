using System.Collections;
using UnityEngine;

public class BossDieState : BossBaseState {
    [SerializeField] string animationName = "die";

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        bossBase.isDead = true;
        boss.animator.SetBool(animationName, true);
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) { }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        
    }
}
