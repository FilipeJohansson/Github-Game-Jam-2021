using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour {
    [SerializeField] BossBaseState currentState;
    public BossSleepState SleepState = new BossSleepState();
    public BossWakeUpState WakeUpState = new BossWakeUpState();
    public BossIdleState IdleState = new BossIdleState();
    public BossWalkState WalkState = new BossWalkState();
    public BossAttackState AttackState = new BossAttackState();
    public BossLayState LayState = new BossLayState();
    public BossDeathState DeathState = new BossDeathState();

    public Animator animator;
    public BossBase bossBase;

    void Awake() {
        animator = gameObject.transform.Find("Sprite").GetComponent<Animator>();
        bossBase = gameObject.GetComponent<BossBase>();
    }

    // Start is called before the first frame update
    void Start() {
        currentState = SleepState;
        currentState.EnterState(this, bossBase);
    }

    // Update is called once per frame
    void Update() {
        currentState.UpdateState(this, bossBase);
        if (bossBase.isDead)
            SwitchState(DeathState);
    }

    public void SwitchState(BossBaseState state) {
        currentState.ExitState(this, bossBase);
        currentState = state;
        state.EnterState(this, bossBase);
    }
}
