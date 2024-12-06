using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : PlayerState
{
    public override string stateName => "Attacking";

    [SerializeField] private Attack attack;
    private Coroutine attackFrameCoroutine;

    private AttackFrameData attackFrameData = new AttackFrameData();

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Enter()
    {
        attackFrameCoroutine = StartCoroutine(attackFrameData.AttackFrameCoroutine(attack));
        animator.Play(attack.animationClip.name);
        core.canMoveX = false;
        base.Enter();
    }

    public override void Exit()
    {
        core.canMoveX = true;
        base.Exit();
    }

    public override State GetNextState()
    {
        if (attackFrameData.attackPhase == AttackPhase.Complete)
        {
            return core.idleState;
        }

        return this;
    }   

}
