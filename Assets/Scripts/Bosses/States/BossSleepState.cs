using System.Collections;
using UnityEngine;

public class BossSleepState : BossBaseState {
    [SerializeField] string animationName = "sleeping";

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, true);
        boss.StartCoroutine(WakeUp(boss));
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, false);
    }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        
    }

    IEnumerator WakeUp(BossStateManager boss) {
        yield return new WaitForSeconds(2f);

        boss.SwitchState(boss.WakeUpState);

        yield return null;
    }
}
