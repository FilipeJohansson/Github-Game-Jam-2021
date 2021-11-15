using System.Collections;
using UnityEngine;

public class BossAttackState : BossBaseState {
    [SerializeField] string animationName = "attacking";

    bool alreadyAttacked = false;

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, true);
        bossBase.isAttacking = true;
        alreadyAttacked = false;
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, false);
        bossBase.isAttacking = false;
    }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        if (!bossBase.posLocked)
            bossBase.LookAtPlayer();

        if (bossBase.attackDelayTimer <= 0) {
            bossBase.SetAttack();
            bossBase.Attack();
            bossBase.ResetAttackDelay();
            alreadyAttacked = true;
        } else if (!alreadyAttacked)
            bossBase.attackDelayTimer -= Time.deltaTime;

        if (!bossBase.canAttack)
            boss.SwitchState(boss.WalkState);
    }
}
