using System.Collections;
using UnityEngine;

public class BossLayState : BossBaseState {
    [SerializeField] string animationName = "laying";

    public override void EnterState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, true);
        boss.StartCoroutine(Walk(boss));
    }

    public override void ExitState(BossStateManager boss, BossBase bossBase) {
        boss.animator.SetBool(animationName, false);
    }

    public override void UpdateState(BossStateManager boss, BossBase bossBase) {
        boss.transform.position = Vector3.Lerp(boss.transform.position, bossBase.slot.transform.position, bossBase.speed * Time.deltaTime);
    }

    IEnumerator Walk(BossStateManager boss) {
        yield return new WaitForSeconds(2f);

        boss.SwitchState(boss.SleepState);

        yield return null;
    }
}
