using System.Collections;
using UnityEngine;

public class BossIdleState : BossBaseState {
    [SerializeField] string animationName = "idlening";

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, true);
        boss.StartCoroutine(Idle(boss));
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, false);
    }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        // throw new System.NotImplementedException();
    }

    IEnumerator Idle(BossStateManager boss) {
        yield return new WaitForSeconds(2f);

        boss.SwitchState(boss.WalkState);

        yield return null;
    }
}
