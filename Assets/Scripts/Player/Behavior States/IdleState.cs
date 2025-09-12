using Unity.VisualScripting;
using UnityEngine;

public class IdleState : PlayerState
{
    public override string stateName => "Idle";

    public override void Enter()
    {
        base.Enter();

        animator.Play("Player Idle");
    }

    public override State GetNextState()
    {
        if (Mathf.Abs(rigidbody.linearVelocityX) > 0.1f)
        {
            return core.run;
        }

        return this;
    }
}
