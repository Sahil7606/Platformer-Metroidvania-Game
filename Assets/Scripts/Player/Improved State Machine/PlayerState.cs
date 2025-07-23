using UnityEngine;

public abstract class PlayerState : State
{
    // Reference to the player core
    protected PlayerCore core;

    // Blackboard objects needed from player core
    protected new Rigidbody2D rigidbody;
    protected Animator animator;
    protected InputManager input;


    // Grants player access to the core and blackboard objects
    public override void SetCore(SMCore _core)
    {
        core = _core as PlayerCore;
        rigidbody = core.rigidbody;
        animator = core.animator;
        input = core.input;
    }
}
