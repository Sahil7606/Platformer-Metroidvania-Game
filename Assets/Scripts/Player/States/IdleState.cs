using UnityEngine;

public class IdleState : PlayerState
{
    public override string stateName => "Idle";
    public override State GetNextState()
    {
        if (Mathf.Abs(input.AxisInput.x) > Mathf.Epsilon)
        {
            return core.runState;
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
