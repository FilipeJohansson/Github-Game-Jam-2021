using System.Collections;
using UnityEngine;

public class BossWalkState : BossBaseState {
    [SerializeField] string animationName = "walking";

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        Debug.Log("Enter Walk State");
        boss.animator.SetBool(animationName, true);
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) {
        Debug.Log("Exit Walk State");
        boss.animator.SetBool(animationName, false);
    }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        bossBase.LookAtPlayer();
        boss.transform.position = Vector3.MoveTowards(boss.transform.position, bossBase.player.transform.position, bossBase.speed * Time.deltaTime);

        // Verify if can attack
        if (bossBase.canAttack) {
            bossBase.ResetAttackTimer();
            boss.SwitchState(boss.AttackState);
        } else {
            bossBase.DecreaseAttackTimer();
            
            if (bossBase.attackTimer <= 0)
                bossBase.canAttack = true;
        }
    }
}
