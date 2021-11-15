using System.Collections;
using UnityEngine;

public class BossWakeUpState : BossBaseState {
    [SerializeField] string animationName = "wakingUp";

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, true);
        boss.StartCoroutine(WakingUp(boss));
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, false);
    }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        
    }

    IEnumerator WakingUp(BossStateManager boss) {
        yield return new WaitForSeconds(2f);

        boss.SwitchState(boss.IdleState);

        yield return null;
    }
}
