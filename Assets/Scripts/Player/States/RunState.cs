using UnityEngine;

public class RunState : PlayerState
{
    public override string stateName => "Running";
    public override void Enter()
    {
        animator.SetBool("IsRunning", true);
    }

    public override void Exit()
    {
        animator.SetBool("IsRunning", false);
    }
    public override State GetNextState()
    {
        if (Mathf.Abs(input.AxisInput.x) < Mathf.Epsilon)
        {
            return core.idleState;
        }

        if (input.jumpButtonDown)
        {
            return core.jumpState;
        }

        if (!core.isGrounded)
        {
            return core.airState;
        }

        return this;
    }
}
