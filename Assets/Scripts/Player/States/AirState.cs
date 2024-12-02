using UnityEngine;

public class AirState : PlayerState
{   
    public override string stateName => "Airborne";

    public override void Enter()
    {
        rigidbody.gravityScale = 9;
    }

    public override State GetNextState()
    {
        if (core.isGrounded)
        {
            return core.idleState;
        }

        return this;
    }
}
