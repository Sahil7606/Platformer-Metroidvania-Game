using UnityEngine;

public class RunState : PlayerState
{
    public override string stateName => "Run";

    public override void Enter()
    {
        base.Enter();

        animator.Play("Player Run");
    }

    public override State GetNextState()
    {
        if (Mathf.Abs(rigidbody.linearVelocityX) < 0.01f)
        {
            return core.idle;
        }

        return this;
    }
}
