using UnityEngine;

public abstract class PlayerState : State
{
    // Reference to the player core
    protected PlayerCore core;

    // Blackboard objects needed from player core
    protected new Rigidbody2D rigidbody;
    protected Animator animator;
    protected InputManager input;
    protected GroundChecker groundChecker;
    protected new Transform transform;


    // Grants player access to the core and blackboard objects
    public override void SetCore(SMCore _core)
    {
        core = _core as PlayerCore;
        rigidbody = core.rigidbody;
        animator = core.animator;
        input = core.input;
        groundChecker = core.groundChecker;
        transform = core.transform;
    }
}
