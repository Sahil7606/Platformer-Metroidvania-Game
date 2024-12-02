using UnityEngine;

public class JumpState : PlayerState
{
    public override string stateName => "Jumping";

    [Header ("Jump Properties")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpHoldStrength;
    [SerializeField] private float maxHoldTime;

    public override void Enter()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        base.Enter();
    }

    public override void StateFixedUpdate()
    {
        rigidbody.velocity += new Vector2(0, jumpHoldStrength - (stateFixedRuntime / 3.5f));
    }

    public override State GetNextState()
    {
        if (!input.jumpButtonDown || stateRuntime >= maxHoldTime)
        {
            return core.airState;
        }

        return this;
    }
}
