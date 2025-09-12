using UnityEngine;

public class JumpState : PlayerState
{
    public override string stateName => "Jump";

    public override void Enter()
    {
        base.Enter();
        //rigidbody.AddForceY();
    }

    public override State GetNextState()
    {
        if (groundChecker.isGrounded)
        {
            return core.idle;
        }

        return this;
    }
}
